using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07_Entity_Framework.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TableID { get; set; }

        // SQL 'int' khớp với C# 'int'
        public int Amount { get; set; }

        // SQL 'float' phải khớp với C# 'double?'
        public double? Discount { get; set; } // Sửa từ int?

        // SQL 'float' phải khớp với C# 'double?'
        public double? Tax { get; set; } // Sửa từ int?

        // SQL 'bit' phải khớp với C# 'bool'
        public bool Status { get; set; } // Sửa từ int

        // Cột này không tồn tại trong DB (ảnh image_c05df7.png)
        // public DateTime? DateCheckIn { get; set; } // Xóa hoặc comment dòng này

        public DateTime? CheckoutDate { get; set; } // SQL 'smalldatetime' khớp 'DateTime?'
        public string Account { get; set; }

        [ForeignKey("TableID")]
        public virtual DiningTable Table { get; set; }

        [ForeignKey("Account")]
        public virtual Account AccountInfo { get; set; }

        public virtual ICollection<BillDetails> BillDetails { get; set; }
    }
}