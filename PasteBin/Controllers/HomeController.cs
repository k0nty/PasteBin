using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasteBin.Data;
using PasteBin.Models;
using System.Diagnostics;

namespace PasteBin.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pastes = await _context.Pastes.ToListAsync();
            return View(pastes);
        }

        [HttpPost]
        public async Task<IActionResult> AddPaste([Bind("PastesID,Link,Title,Content,CreatedAt,ExpirationData,CurrentUserID")] Pastes paste)
        {
            if (ModelState.IsValid)
            {
                paste.Link = Guid.NewGuid().ToString("N").Substring(0, 10);
                paste.ExpirationData = DateTime.Now.AddHours(24);
                _context.Add(paste);

                try
                {
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Paste created successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Error saving paste to database: " + ex.Message });
                }
            }

            return Json(new { success = false, message = "Invalid data" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
