using RealPlazaChallenge.Core.Entities;
using RealPlazaChallenge.Core.Interfaces;
using RealPlazaChallenge.Infrastructure.Data;
using RealPlazaChallenge.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ChallengeContext _context;

        public UserRepository(ChallengeContext context)
        {
            _context = context;
        }

        public Task<int> AddUser(User pr)
        {
            tb_user tb_user = new tb_user
            {
                username = pr.username,
                email = pr.email,
                password = pr.password,
                inserted_time = DateTime.Now,
            };

            _context.users.Add(tb_user);
            _context.SaveChanges();

            int newId = tb_user.id;

            return Task.FromResult(newId);
        }

        public Task<User> GetUserById(int id)
        {
            var user = _context.users.Find(id);

            if (user != null)
            {
                User tb_user = new User
                {
                    username = user.username,
                    email = user.email,
                    password = user.password,
                    inserted_time = user.inserted_time
                };

                return Task.FromResult(tb_user);
            }
            else
                return null;
        }

        public Task<User> GetUserByEmail(string email)
        {
            var user = _context.users.Where(x => x.email.Equals(email)).FirstOrDefault();

            if (user != null)
            {
                User tb_user = new User
                {
                    username = user.username,
                    email = user.email,
                    password = user.password,
                    inserted_time = user.inserted_time
                };

                return Task.FromResult(tb_user);
            }
            else
                return null;
        }
    }
}
