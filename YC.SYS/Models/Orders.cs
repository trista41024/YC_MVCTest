using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YC.SYS.Models
{
    [Table("Orders", Schema = "dbo")]
    public class Orders
    {
        /// <summary>訂單編號</summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderID")]
        public int OrderID { get; set; }

        /// <summary>客戶編號</summary>
        [MaxLength(5)]
        [Column("CustomerID")]
        public string? CustomerID { get; set; }

        /// <summary>員工編號</summary>
        [Column("EmployeeID")]
        public int? EmployeeID { get; set; }

        /// <summary>訂購日期</summary>
        [Column("OrderDate")]
        public DateTime? OrderDate { get; set; }

        /// <summary>預計到達日期</summary>
        [Column("RequiredDate")]
        public DateTime? RequiredDate { get; set; }

        /// <summary>出貨日期</summary>
        [Column("ShippedDate")]
        public DateTime? ShippedDate { get; set; }

        /// <summary>運送方式</summary>
        [Column("ShipVia")]
        public int? ShipVia { get; set; }

        /// <summary>運費</summary>
        [Column("Freight")]
        public decimal? Freight { get; set; }

        /// <summary>收貨人姓名</summary>
        [MaxLength(40)]
        [Column("ShipName")]
        public string? ShipName { get; set; }

        /// <summary>收貨地址</summary>
        [MaxLength(60)]
        [Column("ShipAddress")]
        public string? ShipAddress { get; set; }

        /// <summary>收貨所在城市</summary>
        [MaxLength(15)]
        [Column("ShipCity")]
        public string? ShipCity { get; set; }

        /// <summary>收貨所在地區</summary>
        [MaxLength(15)]
        [Column("ShipRegion")]
        public string? ShipRegion { get; set; }

        /// <summary>收貨郵遞區號</summary>
        [MaxLength(10)]
        [Column("ShipPostalCode")]
        public string? ShipPostalCode { get; set; }

        /// <summary>收貨國家</summary>
        [MaxLength(15)]
        [Column("ShipCountry")]
        public string? ShipCountry { get; set; }
    }
}
