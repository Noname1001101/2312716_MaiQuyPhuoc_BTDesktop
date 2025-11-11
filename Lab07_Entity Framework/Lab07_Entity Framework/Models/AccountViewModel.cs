using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab07_Entity_Framework.Models
{
    internal class AccountViewModel
    {
        public string AccountName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }
        public DateTime? DateCreated { get; set; }
        public string RoleName { get; set; }
        public string TrangThai { get; set; }
    }
}
