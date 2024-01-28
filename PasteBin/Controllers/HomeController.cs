using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasteBin.Data;
using PasteBin.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PasteBin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPaste([Bind("PastesID,Link,Title,Content,ExpirationData,CurrentUserID")] Pastes paste)
        {
            if (ModelState.IsValid)
            {
                paste.Link = Guid.NewGuid().ToString("N").Substring(0, 10);
                paste.ExpirationData = DateTime.Now.AddHours(24);
                _context.Add(paste);

                try
                {
                    await _context.SaveChangesAsync();

                    // Передайте посилання на ViewPaste в представлення
                    var pasteLink = Url.Action("ViewPaste", new { link = paste.Link });
                    return Json(new { success = true, message = "Paste created successfully", link = pasteLink });
                }
                catch (Exception ex)
                {
                    // Обробка помилок при збереженні в базу даних.
                    Console.WriteLine("Error saving paste to database: " + ex.Message);
                    return Json(new { success = false, message = "Error saving paste to database" });
                }
            }

            // Обробка випадку, коли дані невірні.
            return Json(new { success = false, message = "Invalid data" });
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ViewPaste(string link)
        {
            if (string.IsNullOrEmpty(link))
            {
                // Обробка випадку, коли посилання не вказане.
                return RedirectToAction("Index");
            }

            var paste = await _context.Pastes.FirstOrDefaultAsync(p => p.Link == link);

            if (paste == null)
            {
                // Обробка випадку, коли паста з вказаним посиланням не знайдена.
                return RedirectToAction("Index");
            }

            return View(paste);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
