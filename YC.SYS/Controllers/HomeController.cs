using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using YC.SYS.Models;
using static YC.SYS.ViewModels.OrdersVM;

namespace YC.SYS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await GetOrdersAsync();
            return View(orders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<List<OrderListViewModel>> GetOrdersAsync()
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
                                          TotalAmount = orderDetailsGroup
                                              .Sum(od => od.UnitPrice * od.Quantity * (1 - (decimal)od.Discount))
                                              + (o.Freight ?? 0)
                                      }).ToListAsync();

            return ordersDetail;
        }
    }
}
