using Demo.DataAccess.src;
using Demo.DataAccess.src.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Demo.DataAccess
{
    public class Program
    {
        private static HttpClient httpClient;

        public static EntityContext ec = new EntityContext();
        public static async Task Main(string[] args)
        {
            //SaveRoles();
            //SaveUser();
            //SaveFuncation();
            //FindUser();
            //var str = FindRoles();
            //FindUserSql();

            // System.Diagnostics.Debug.WriteLine(str);

            //DbExceptionTest();

            //EntityState();

            //HttpPostAsync();

            var test = new OAuthClientTest();
            var token = await test.GetAccessToken();
            Console.WriteLine(token);
            Console.ReadKey();

        }

        private static async void HttpPostAsync()
        {
            string username = "aaaaaa";
            string password = "123321";

            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            };

            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("http://localhost:5748");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
               "Basic",
               Convert.ToBase64String(Encoding.ASCII.GetBytes("1234:5678"))
               );

            var response = await httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var access_token = JObject.Parse(result)["access_token"].Value<string>();
            Console.WriteLine(access_token);
            Console.ReadKey();
        }

        private static void DbExceptionTest()
        {
            var roles = ec.Roles.Find(1);

            roles.RName = "角色测试";
            Boolean isSave;


            do
            {
                isSave = false;
                try
                {

                    ec.Database.ExecuteSqlCommand("update my_demo_roles set rname = '测试1号' where rid = 1");

                    ec.SaveChanges();

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var entry = ex.Entries.Single();
                    var current = entry.CurrentValues;
                    var database = entry.GetDatabaseValues();
                    var resolved = database.Clone();

                    Print(current, database, resolved);

                    isSave = true;
                }


            } while (isSave);
        }

        public static void Print(DbPropertyValues current, DbPropertyValues database, DbPropertyValues resolved)
        {
            var c = JsonConvert.SerializeObject(current);
            Console.WriteLine(c);
            var d = JsonConvert.SerializeObject(database);
            Console.WriteLine(d);
            var r = JsonConvert.SerializeObject(resolved);
            Console.WriteLine(r);
            Console.ReadKey();
        }

        private static void EntityState()
        {
            //找到角色数据  有包含 funcationId   1 2 4
            Roles roles = ec.Roles.Find(1);


            //如果要在中间表添加 funcation 3  就需要从数据库拿到 3 的数据
            //也可以  自己创建一个 id为3 的数据  再修改状态
            Function function3 = new Function() { FunctionId = 3 };
            //设置  自己创建的 funcation 没有被修改过(和刚从数据库中查询出来一样)
            //如果不改状态 保存的时候  funcation表 会新增id 不为3的数据  这样就会导致设置错误
            var dbEntityEntry = ec.Entry(function3);
            dbEntityEntry.State = System.Data.Entity.EntityState.Unchanged;

            var list = new List<Function> { };
            list.Add(function3);

            //添加到 角色的 funcatinList中   funcatinList 的状态就改变了
            //中间表会新增数据但是  funcation表不会新增
            roles.FunctionsList = list;

            var e = ec.Entry(roles);

            //ec.Roles
            ec.SaveChanges();
        }

        private static void FindUserSql()
        {
            string name = "张";
            var list = (from user in ec.User where user.Name.Contains(name) select user).ToList<User>();

            //var list = ec.Database.SqlQuery<User>("select * from my_demo_user where name = @name",new SqlParameter("@name", name));

            foreach (var user in list)
            {
                Console.WriteLine("id={0}", user.UId);
                Console.WriteLine("name={0}", user.Name);
                Console.WriteLine("age={0}", user.Age);
            }

            Console.ReadKey();
        }

        public static void SaveUser()
        {
            var user = new User()
            {
                Name = "张三",
                Age = 21,
                RId = 1
            };
            ec.User.Add(user);
            var user1 = new User()
            {
                Name = "李四",
                Age = 25,
                RId = 2
            };
            ec.User.Add(user1);
            var user2 = new User()
            {
                Name = "张2",
                Age = 21,
                RId = 2
            };
            ec.User.Add(user2);
            ec.SaveChanges();
        }
        public static void SaveRoles()
        {
            var roles = new Roles()
            {
                RName = "角色1"
            };
            ec.Roles.Add(roles);
            var roles2 = new Roles()
            {
                RName = "角色3"
            };
            ec.Roles.Add(roles2);
            ec.SaveChanges();
        }
        public static void SaveFuncation()
        {
            Roles roles = ec.Roles.Find(1);
            var list = new List<Roles> { };
            list.Add(roles);

            Function function = new Function()
            {
                Name = "api/users/name",
                RolesList = list
            };
            ec.Functions.Add(function);
            ec.SaveChanges();
        }
        public static void FindUser()
        {
            User user = ec.User.Find(1);
            Console.WriteLine("name={0}", user.Name);
            Console.WriteLine("age={0}", user.Age);
            Console.WriteLine("Roles.rname={0}", user.Roles.RName);
            Console.ReadKey();

        }
        public static string FindRoles()
        {
            string str;
            var role = ec.Roles.Find(2);
            //Roles roles = new Roles()
            //{
            //    RId = role.RId,
            //    RName = role.RName
            //};

            return JsonConvert.SerializeObject(role);
            //Console.WriteLine("RId={0}", roles.RId);
            //Console.WriteLine("RName={0}", roles.RName);
            //Console.WriteLine("UserList={0}", roles.UserList.Count);
            //Console.ReadKey();

        }
    }
}