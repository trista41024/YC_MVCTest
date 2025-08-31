using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YC.SYS.Models;
using YC.SYS.Services;

namespace YC.SYS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _context;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, NorthwindContext context, IOrderService orderService)
        {
            _logger = logger;
            _context = context;
            _orderService = orderService;
        }

        /// <summary>
        /// ���o�Ҧ��q����
        /// </summary>
        /// <returns>�q��C��</returns>
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();
            return View(orders);
        }

        /// <summary>
        /// ���o��@�q��ԲӸ��
        /// </summary>
        /// <returns>�q��ԲӸ��</returns>
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderDetailAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return PartialView("_OrderDetailsPartial", order);
        }

        /// <summary>
        /// �s�حq����
        /// </summary>
        /// <returns>�ťժ��q����</returns>
        public IActionResult Create()
        {
            var order = new Orders { };
            return PartialView("_OrderFormPartial", order);
        }

        /// <summary>
        /// ���o�s��q����
        /// </summary>
        /// <returns>�q����</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            return PartialView("_OrderFormPartial", order);
        }

        /// <summary>
        /// �x�s�q����
        /// </summary>
        /// <returns>�x�s���G</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Orders order)
        {
            var isEdit = order.OrderID > 0;
            var message = isEdit ? "�q���s" : "�q��s�W";
            try
            {
                if (!isEdit) _context.Orders.Add(order);
                else _context.Orders.Update(order);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = message + "���\�I" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = message + "���ѡG" + ex.Message });
            }
        }

        /// <summary>
        /// �R���q����
        /// </summary>
        /// <returns>�R�����G</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order != null)
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                }

                return Json(new { success = true, message = "�q��R�����\�I" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "�R�����ѡG" + ex.Message });
            }
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
    }
}
