using Microsoft.EntityFrameworkCore;
using static YC.SYS.ViewModels.OrdersVM;

namespace YC.SYS.Services
{
    public interface IOrderService
    {
        Task<List<OrderListViewModel>> GetOrdersAsync();
        Task<OrderDetailViewModel?> GetOrderDetailAsync(int orderId);
    }

    public class OrderService : IOrderService
    {
        private readonly NorthwindContext _context;

        public OrderService(NorthwindContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 取得所有訂單的列表資料
        /// </summary>
        /// <returns>訂單列表</returns>
        public async Task<List<OrderListViewModel>> GetOrdersAsync()
        {
            var ordersDetail = await (from o in _context.Orders
                                      join c in _context.Customers on o.CustomerID equals c.CustomerID
                                      join e in _context.Employees on o.EmployeeID equals e.EmployeeID
                                      join od in _context.OrderDetails on o.OrderID equals od.OrderID into orderDetailsGroup
                                      select new OrderListViewModel
                                      {
                                          OrderID = o.OrderID,
                                          CustomerName = c.ContactName,
                                          EmployeeName = e.FirstName + " " + e.LastName,
                                          OrderDate = o.OrderDate,
                                          ShippedDate = o.ShippedDate,
                                          ShipCity = o.ShipCity,
                                          // 加總金額
                                          TotalAmount = orderDetailsGroup
                                              .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
                                              + (o.Freight ?? 0)
                                      }).ToListAsync();

            return ordersDetail;
        }

        /// <summary>
        /// 取得指定的訂單資料
        /// </summary>
        /// <param name="orderId">訂單編號</param>
        /// <returns>單筆訂單資料</returns>
        public async Task<OrderDetailViewModel?> GetOrderDetailAsync(int orderId)
        {
            var orderInfo = await (from o in _context.Orders
                                   join c in _context.Customers on o.CustomerID equals c.CustomerID
                                   join e in _context.Employees on o.EmployeeID equals e.EmployeeID
                                   where o.OrderID == orderId
                                   select new
                                   {
                                       Order = o,
                                       CustomerName = c.ContactName,
                                       CustomerCompany = c.CompanyName,
                                       EmployeeName = e.FirstName + " " + e.LastName
                                   }).FirstOrDefaultAsync();

            if (orderInfo == null) return null;

            var products = await (from od in _context.OrderDetails
                                  join p in _context.Products on od.ProductID equals p.ProductID
                                  where od.OrderID == orderId
                                  select new ProductViewModel
                                  {
                                      ProductID = od.ProductID,
                                      ProductName = p.ProductName,
                                      UnitPrice = od.UnitPrice,
                                      Quantity = od.Quantity,
                                      Discount = od.Discount,
                                      // 折扣扣金額
                                      Subtotal = od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount)
                                  }).ToListAsync();

            var orderDetail = new OrderDetailViewModel
            {
                OrderID = orderInfo.Order.OrderID,
                CustomerName = orderInfo.CustomerName,
                CustomerCompany = orderInfo.CustomerCompany,
                EmployeeName = orderInfo.EmployeeName,
                OrderDate = orderInfo.Order.OrderDate,
                RequiredDate = orderInfo.Order.RequiredDate,
                ShippedDate = orderInfo.Order.ShippedDate,
                ShipName = orderInfo.Order.ShipName,
                ShipAddress = orderInfo.Order.ShipAddress,
                ShipCity = orderInfo.Order.ShipCity,
                ShipRegion = orderInfo.Order.ShipRegion,
                ShipPostalCode = orderInfo.Order.ShipPostalCode,
                ShipCountry = orderInfo.Order.ShipCountry,
                Freight = orderInfo.Order.Freight ?? 0,
                OrderDetails = products,
                TotalAmount = products.Sum(x => x.Subtotal) + (orderInfo.Order.Freight ?? 0)
            };

            return orderDetail;
        }
    }
}
