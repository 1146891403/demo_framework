using Demo.DataAccess.src;
using Demo.DataAccess.src.Entities;
using Demo.Repository.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.src.Services
{
    public class UserRepository : IUserRepository
    {
        EntityContext ec;

        public UserRepository()
        {
             ec = new EntityContext();
        }

        public User FindById(long id)
        {
            return ec.User.Find(id);
        }

        public List<User> FindByName(string name)
        {
            return (ec.Database.SqlQuery<User>("select * from my_demo_user where name = @name",new SqlParameter("@name", name))).ToList();
        }

        public List<User> GetAll()
        {
            return ec.User.ToList();
        }

        public bool Insert(User user)
        {
            ec.User.Add(user);

            return ec.SaveChanges() > 0 ? true : false;
        }

        public bool Update(User user)
        {
            ec.User.Add(user);

            return ec.SaveChanges() > 0 ? true : false;
        }
    }
}
