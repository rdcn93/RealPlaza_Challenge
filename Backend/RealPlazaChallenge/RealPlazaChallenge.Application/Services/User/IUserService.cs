using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Application.Services.User
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserService" en el código y en el archivo de configuración a la vez.
    public interface IUserService
    {
        Task<int> AddUser(UserModel newU);
        Task<UserViewModel> GetUserById(int id);
        Task<UserViewModel> GetUserByEmail(string email);
    }
}
