// Lab07_Entity_Framework.Models/Account.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab07_Entity_Framework.Models
{
    public class Account
    {
        [Key]
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }

        // Sửa ở đây: Thêm dấu ?
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }
    }
}