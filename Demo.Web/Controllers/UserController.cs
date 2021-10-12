using Demo.DataAccess.src;
using Demo.DataAccess.src.Entities;
using Demo.Services.src.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Demo.Web.Controllers
{
    /*
    private EntityContext db = new EntityContext();
    public string Index()
    {
        var data = db.Students.ToList();
        return "Database is build success!";
    }
    */
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserService _userServices;

        public UserController(IUserService userServices)
        {
            System.Diagnostics.Debug.WriteLine("UserController");
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
        }

        [Route("get_user/{id}"), HttpGet]
        public UserEditModel GetUser(int id)
        {
            return _userServices.GetUserById(id);
        }

        [Route("get_user_name/{name}"), HttpGet]
        public List<UserEditModel> GetUser(string name)
        {
            return _userServices.GetUserByName(name);
        }

        [Route("get_all"), HttpGet]
        public List<UserEditModel> GetAll()
        {
            return _userServices.GetAll();
        }

        [Route("test"), HttpGet]
        public String Test() {
            System.Diagnostics.Debug.WriteLine("测试项");
            return "测试";
        }
    }
}