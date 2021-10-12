using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Entities
{
    public class Function
    {

        public Function()
        {
            CreateDate = DateTime.Now;
        }

        public long FunctionId { get; set; }
        

        public string Name { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual ICollection<Roles> RolesList { get; set; }
    }
}
