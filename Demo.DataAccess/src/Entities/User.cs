using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.src.Entities
{
    public class User
    {
        public long UId { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
        public long? RId { get; set; }

        public virtual Roles Roles { get; set; }

    }
}
