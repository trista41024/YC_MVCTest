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

        /// <summary>單筆訂單詳細資料</summary>
        public class OrderDetailViewModel
        {
            /// <summary>訂單編號</summary>
            public int OrderID { get; set; }

            /// <summary>客戶姓名</summary>
            public string? CustomerName { get; set; }

            /// <summary>客戶公司</summary>
            public string? CustomerCompany { get; set; }

            /// <summary>負責員工</summary>
            public string? EmployeeName { get; set; }

            /// <summary>訂購日期</summary>
            public DateTime? OrderDate { get; set; }

            /// <summary>要求日期</summary>
            public DateTime? RequiredDate { get; set; }

            /// <summary>出貨日期</summary>
            public DateTime? ShippedDate { get; set; }

            /// <summary>收貨人</summary>
            public string? ShipName { get; set; }

            /// <summary>收貨地址</summary>
            public string? ShipAddress { get; set; }

            /// <summary>收貨城市</summary>
            public string? ShipCity { get; set; }

            /// <summary>收貨地區</summary>
            public string? ShipRegion { get; set; }

            /// <summary>郵遞區號</summary>
            public string? ShipPostalCode { get; set; }

            /// <summary>收貨國家</summary>
            public string? ShipCountry { get; set; }

            /// <summary>運費</summary>
            public decimal Freight { get; set; }

            /// <summary>訂單明細項目</summary>
            public List<ProductViewModel> OrderDetails { get; set; } = new List<ProductViewModel>();

            /// <summary>總金額</summary>
            public decimal TotalAmount { get; set; }

            /// <summary>訂單狀態</summary>
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

        /// <summary>產品清單資料</summary>
        public class ProductViewModel
        {
            /// <summary>產品編號</summary>
            public int ProductID { get; set; }

            /// <summary>產品名稱</summary>
            public string? ProductName { get; set; }

            /// <summary>單價</summary>
            public decimal UnitPrice { get; set; }

            /// <summary>數量</summary>
            public short Quantity { get; set; }

            /// <summary>折扣</summary>
            public float Discount { get; set; }

            /// <summary>小計</summary>
            public decimal Subtotal { get; set; }
        }
    }
}
