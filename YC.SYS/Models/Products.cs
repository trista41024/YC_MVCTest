using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YC.SYS.Models
{
    [Table("Products", Schema = "dbo")]
    public class Products
    {
        /// <summary>產品編號</summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductID")]
        public int ProductID { get; set; }

        /// <summary>產品名稱</summary>
        [Required]
        [MaxLength(40)]
        [Column("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        /// <summary>供應商編號</summary>
        [Column("SupplierID")]
        public int? SupplierID { get; set; }

        /// <summary>分類編號</summary>
        [Column("CategoryID")]
        public int? CategoryID { get; set; }

        /// <summary>數量</summary>
        [MaxLength(20)]
        [Column("QuantityPerUnit")]
        public string? QuantityPerUnit { get; set; }

        /// <summary>單價</summary>
        [Column("UnitPrice")]
        public decimal? UnitPrice { get; set; }

        /// <summary>庫存數量</summary>
        [Column("UnitsInStock")]
        public short? UnitsInStock { get; set; }

        /// <summary>訂購量</summary>
        [Column("UnitsOnOrder")]
        public short? UnitsOnOrder { get; set; }

        /// <summary>再次訂購量</summary>
        [Column("ReorderLevel")]
        public short? ReorderLevel { get; set; }

        /// <summary>中止</summary>
        [Required]
        [Column("Discontinued")]
        public bool Discontinued { get; set; }
    }
}
