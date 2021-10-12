using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Entities
{
    public class Roles
    {
        public long RId { get; set; }
        public string RName { get; set; }
   
       // public DateTime CreateDate { get; set; }
       
        public virtual ICollection<User> UserList { get; set; }

        public virtual ICollection<Function> FunctionsList { get; set; }

        
    }
}
