using Demo.DataAccess.src;
using Demo.DataAccess.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.src.Interfaces
{
    public interface IUserRepository : ITransientDependency
    {
        User FindById(long id);

        List<User> FindByName(string name);

        List<User> GetAll();

        bool Insert(User user);

        bool Update(User user);

    }
}
