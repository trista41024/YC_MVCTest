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
        /// 取得所有訂單資料
        /// </summary>
        /// <returns>訂單列表</returns>
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersAsync();
            return View(orders);
        }

        /// <summary>
        /// 取得單一訂單詳細資料
        /// </summary>
        /// <returns>訂單詳細資料</returns>
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
        /// 新建訂單資料
        /// </summary>
        /// <returns>空白的訂單資料</returns>
        public IActionResult Create()
        {
            var order = new Orders { };
            return PartialView("_OrderFormPartial", order);
        }

        /// <summary>
        /// 取得編輯訂單資料
        /// </summary>
        /// <returns>訂單資料</returns>
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            return PartialView("_OrderFormPartial", order);
        }

        /// <summary>
        /// 儲存訂單資料
        /// </summary>
        /// <returns>儲存結果</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Orders order)
        {
            var isEdit = order.OrderID > 0;
            var message = isEdit ? "訂單更新" : "訂單新增";
            try
            {
                if (!isEdit) _context.Orders.Add(order);
                else _context.Orders.Update(order);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = message + "成功！" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = message + "失敗：" + ex.Message });
            }
        }

        /// <summary>
        /// 刪除訂單資料
        /// </summary>
        /// <returns>刪除結果</returns>
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

                return Json(new { success = true, message = "訂單刪除成功！" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "刪除失敗：" + ex.Message });
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
