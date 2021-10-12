using Demo.DataAccess.src;
using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services.src.Interfaces
{
    public interface IUserService : ITransientDependency
    {
        UserEditModel GetUserById(long id);

        List<UserEditModel> GetUserByName(string name);

        List<UserEditModel> GetAll();

    }
}
