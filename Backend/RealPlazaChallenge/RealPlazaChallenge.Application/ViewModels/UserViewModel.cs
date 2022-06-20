using RealPlazaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            id = user.id;
            username = user.username;
            email = user.email;
            password = user.password;
            inserted_time = user.inserted_time;
        }

        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime inserted_time { get; set; }
    }
}
