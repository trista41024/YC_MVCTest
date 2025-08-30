using System.ComponentModel.DataAnnotations;

namespace YC.SYS.ViewModels
{
    public class OrdersVM
    {
        /// <summary>總體訂單列表</summary>
        public class OrderListViewModel
        {
            /// <summary>訂單編號</summary>
            [Display(Name = "訂單編號")]
            public int OrderID { get; set; }

            /// <summary>客戶姓名</summary>
            [Display(Name = "客戶姓名")]
            public string? CustomerName { get; set; }

            /// <summary>負責員工</summary>
            [Display(Name = "負責員工")]
            public string? EmployeeName { get; set; }

            /// <summary>訂購日期</summary>
            [Display(Name = "訂購日期")]
            [DataType(DataType.Date)]
            public DateTime? OrderDate { get; set; }

            /// <summary>出貨日期</summary>
            [Display(Name = "出貨日期")]
            [DataType(DataType.Date)]
            public DateTime? ShippedDate { get; set; }

            /// <summary>送貨城市</summary>
            [Display(Name = "送貨城市")]
            public string? ShipCity { get; set; }

            /// <summary>總金額</summary>
            [Display(Name = "總金額")]
            public decimal TotalAmount { get; set; }

            /// <summary>訂單狀態</summary>
            [Display(Name = "訂單狀態")]
            public string Status => GetOrderStatus();

            private string GetOrderStatus()
            {
                if (ShippedDate.HasValue)
                    return "已出貨";
                else if (OrderDate.HasValue && OrderDate <= DateTime.Now)
                    return "處理中";
                else
                    return "未處理";
            }
        }

    }
}
