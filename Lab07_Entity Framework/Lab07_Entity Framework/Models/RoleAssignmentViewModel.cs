using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07_Entity_Framework.Models
{
    internal class RoleAssignmentViewModel
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public bool Assigned { get; set; } // Checkbox
        public string Notes { get; set; }
    }
}
