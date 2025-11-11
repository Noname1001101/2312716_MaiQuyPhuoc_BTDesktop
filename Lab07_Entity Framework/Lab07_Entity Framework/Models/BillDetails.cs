using System.ComponentModel.DataAnnotations.Schema;

namespace Lab07_Entity_Framework.Models
{
    public class BillDetails
    {
        public int ID { get; set; }

        [Column("InvoiceID")] // Map với tên cột thật trong CSDL
        public int BillID { get; set; } // Đặt tên thuộc tính là BillID

        public int FoodID { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("BillID")]
        public virtual Bill Bill { get; set; }

        [ForeignKey("FoodID")]
        public virtual Food Food { get; set; }
    }
}