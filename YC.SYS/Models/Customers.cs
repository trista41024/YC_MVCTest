using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YC.SYS.Models
{
    [Table("Customers", Schema = "dbo")]
    public class Customers
    {
        /// <summary>客戶編號</summary>
        [Key]
        [Required]
        [MaxLength(5)]
        [Column("CustomerID")]
        public required string CustomerID { get; set; }

        /// <summary>公司名稱</summary>
        [Required]
        [MaxLength(40)]
        [Column("CompanyName")]
        public required string CompanyName { get; set; }

        /// <summary>客戶姓名</summary>
        [MaxLength(30)]
        [Column("ContactName")]
        public string? ContactName { get; set; }

        /// <summary>客戶職稱</summary>
        [MaxLength(30)]
        [Column("ContactTitle")]
        public string? ContactTitle { get; set; }

        /// <summary>聯絡地址</summary>
        [MaxLength(60)]
        [Column("Address")]
        public string? Address { get; set; }

        /// <summary>所在城市</summary>
        [MaxLength(15)]
        [Column("City")]
        public string? City { get; set; }

        /// <summary>所在地區</summary>
        [MaxLength(15)]
        [Column("Region")]
        public string? Region { get; set; }

        /// <summary>郵遞區號</summary>
        [MaxLength(10)]
        [Column("PostalCode")]
        public string? PostalCode { get; set; }

        /// <summary>國家</summary>
        [MaxLength(15)]
        [Column("Country")]
        public string? Country { get; set; }

        /// <summary>電話</summary>
        [MaxLength(24)]
        [Column("Phone")]
        public string? Phone { get; set; }

        /// <summary>傳真</summary>
        [MaxLength(24)]
        [Column("Fax")]
        public string? Fax { get; set; }
    }
}
