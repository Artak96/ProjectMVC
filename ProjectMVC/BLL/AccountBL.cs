using ProjectMVC.Data.Models;
using ProjectMVC.Data.Repositoryes;
using ProjectMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.BLL
{
    public class AccountBL
    {
        UserRepository _userRepository;
        public AccountBL(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Registration(RegistrationViewModel user)
        {
            var userDAL = new User
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone
            };
            if(_userRepository.List().Where(u=>u.Email==userDAL.Email).FirstOrDefault() is null)
            {
                _userRepository.Add(userDAL);
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
