using RealPlazaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<int> AddUser(User pr);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
    }
}
