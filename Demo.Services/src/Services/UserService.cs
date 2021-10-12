using Demo.DataAccess.src.Entities;
using Demo.Repository.src.Interfaces;
using Demo.Services.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.src.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            System.Diagnostics.Debug.WriteLine("UserService");
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public UserEditModel GetUserById(long id)
        {
            var user = _userRepository.FindById(id);

            var result = new UserEditModel()
            {
                UId = user.UId,
                RId = user.RId,
                Name = user.Name,
                Age = user.Age,
                RolesEditModel = new RolesEditModel()
                {
                    RId = user.Roles.RId,
                    RName = user.Roles.RName
                }

            };
            return result;
        }

        public List<UserEditModel> GetUserByName(string name)
        {
            var list = _userRepository.FindByName(name);
            var modelList = new List<UserEditModel>();

            foreach(var user in list)
            {
                var result = new UserEditModel()
                {
                    UId = user.UId,
                    RId = user.RId,
                    Name = user.Name,
                    Age = user.Age,
                    RolesEditModel = new RolesEditModel()
                    {
                        RId = user.Roles.RId,
                        RName = user.Roles.RName
                    }

                };
                modelList.Add(result);
            }
            
            return modelList;
        }

        public List<UserEditModel> GetAll()
        {
            var list = _userRepository.GetAll();
            List<UserEditModel> userList = new List<UserEditModel>();

            foreach(var user in list)
            {
                var result = new UserEditModel()
                {
                    UId = user.UId,
                    RId = user.RId,
                    Name = user.Name,
                    Age = user.Age,
                    RolesEditModel = new RolesEditModel()
                    {
                        RId = user.Roles.RId,
                        RName = user.Roles.RName
                    }

                };
                userList.Add(result);

            }

            return userList;
        }

        
    }
}
