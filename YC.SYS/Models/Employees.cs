using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YC.SYS.Models
{
    [Table("Employees", Schema ="dbo")]
    public class Employees
    {
        /// <summary>員工編號</summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "EmployeeID")]
        public int EmployeeID { get; set; }

        /// <summary>姓氏</summary>
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "LastName")]
        public required string LastName { get; set; }

        /// <summary>名字</summary>
        [Required]
        [MaxLength(10)]
        [Column(TypeName = "FirstName")]
        public required string FirstName { get; set; }

        /// <summary>職稱</summary>
        [MaxLength(30)]
        [Column(TypeName = "Title")]
        public string? Title { get; set; }

        /// <summary>稱謂</summary>
        [MaxLength(25)]
        [Column(TypeName = "TitleOfCourtesy")]
        public string? TitleOfCourtesy { get; set; }

        /// <summary>生日</summary>
        [Column(TypeName = "BirthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>雇用日期</summary>
        [Column(TypeName = "HireDate")]
        public DateTime? HireDate { get; set; }

        /// <summary>地址</summary>
        [MaxLength(60)]
        [Column(TypeName = "Address")]
        public string? Address { get; set; }

        /// <summary>所在城市</summary>
        [MaxLength(15)]
        [Column(TypeName = "City")]
        public string? City { get; set; }

        /// <summary>所在地區</summary>
        [MaxLength(15)]
        [Column(TypeName = "Region")]
        public string? Region { get; set; }

        /// <summary>郵遞區號</summary>
        [MaxLength(10)]
        [Column(TypeName = "PostalCode")]
        public string? PostalCode { get; set; }

        /// <summary>國家</summary>
        [MaxLength(15)]
        [Column(TypeName = "Country")]
        public string? Country { get; set; }

        /// <summary>住家電話</summary>
        [MaxLength(24)]
        [Column(TypeName = "HomePhone")]
        public string? HomePhone { get; set; }

        /// <summary>分機號碼</summary>
        [MaxLength(4)]
        [Column(TypeName = "Extension")]
        public string? Extension { get; set; }

        /// <summary>照片</summary>
        [Column(TypeName = "Photo")]
        public byte[]? Photo { get; set; }

        /// <summary>備註</summary>
        [Column(TypeName = "Notes")]
        public string? Notes { get; set; }

        /// <summary>上級主管員工編號</summary>
        [Column(TypeName = "ReportsTo")]
        public int? ReportsTo { get; set; }

        /// <summary>照片路徑</summary>
        [MaxLength(255)]
        [Column(TypeName = "PhotoPath")]
        public string? PhotoPath { get; set; }
    }
}
