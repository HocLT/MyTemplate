using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTemplate.Controllers
{
  public class ProductController : Controller
  {
    private readonly ILogger<ProductController> _logger;

    private readonly AppDbContext _context;

    public ProductController(ILogger<ProductController> logger, AppDbContext context)
    {
      _logger = logger;
      _context = context;
    }

    public async Task<IActionResult> Index()
    {
      return View(await _context.Products.ToListAsync());
    }

    [Route("{pid:int}")]
    public IActionResult AddToCart([FromRoute] int pid)
    {

      var product = _context.Products
            .Where(p => p.ProductId == pid)
            .FirstOrDefault();

      if (product == null)
        return NotFound("No Product");

      // Xử lý đưa vào Cart ...


      return RedirectToAction(nameof(Cart));
    }
    /// xóa item trong cart
    [Route("{pid:int}")]
    public IActionResult RemoveCart([FromRoute] int pid)
    {

      // Xử lý xóa một mục của Cart ...
      return RedirectToAction(nameof(Cart));
    }

    /// Cập nhật
    [HttpPost]
    public IActionResult UpdateCart([FromForm] int pid, [FromForm] int quantity)
    {
      // Cập nhật Cart thay đổi số lượng quantity ...

      return RedirectToAction(nameof(Cart));
    }


    // Hiện thị giỏ hàng
    public IActionResult Cart()
    {
      return View();
    }

    public IActionResult CheckOut()
    {
      // Xử lý khi đặt hàng
      return View();
    }
  }
}
