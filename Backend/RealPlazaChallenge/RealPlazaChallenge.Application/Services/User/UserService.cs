using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.ViewModels;
using RealPlazaChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Application.Services.User
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserService" en el código y en el archivo de configuración a la vez.
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUser(UserModel newU)
        {
            Core.Entities.User pro = new Core.Entities.User
            {
                username = newU.username,
                email = newU.email,
                password = newU.password,
                inserted_time = DateTime.Now,
            };
            var id = await _userRepository.AddUser(pro);

            return id;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            UserViewModel productVM = new UserViewModel(user);

            return productVM;
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            UserViewModel productVM = new UserViewModel(user);

            return productVM;
        }
    }
}
