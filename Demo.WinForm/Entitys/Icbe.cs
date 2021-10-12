using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.WinForm.Entitys
{
    public class Icbe
    {
        public string Id { get; set; }

        public string ParentId { get; set; }

        public string DisplayName { get; set; }

        public Icbe(string id, string parentId, string displayName)
        {
            Id = id;
            ParentId = parentId;
            DisplayName = displayName;
        }
    }
}
