using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07_Entity_Framework.Models
{
    [Table("Table")] // Chỉ định tên bảng thật trong CSDL là "Table"
    public class DiningTable
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        // 0 = Trống, 1 = Có khách
        public int Status { get; set; }
        public int Capacity { get; set; }

        // Quan hệ: Một bàn có nhiều hóa đơn
        public virtual ICollection<Bill> Bill { get; set; }
    }
}