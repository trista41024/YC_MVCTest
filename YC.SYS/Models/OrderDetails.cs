using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YC.SYS.Models
{
    [Table("Order Details", Schema = "dbo")]
    public class OrderDetails
    {
        /// <summary>訂單編號</summary>
        [Required]
        [Column("OrderID")]
        public int OrderID { get; set; }

        /// <summary>產品編號</summary>
        [Required]
        [Column("ProductID")]
        public int ProductID { get; set; }

        /// <summary>單價</summary>
        [Required]
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }

        /// <summary>數量</summary>
        [Required]
        [Column("Quantity")]
        public short Quantity { get; set; }

        /// <summary>折扣</summary>
        [Required]
        [Column("Discount")]
        public float Discount { get; set; }
    }
}
