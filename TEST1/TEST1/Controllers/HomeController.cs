using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEST1.Models;

namespace TEST1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "ASP.NET 8 MVC deployed successfully!";
            return View();
        }

        [HttpGet]
        public IActionResult Contact() => View();

        [HttpPost]
        public IActionResult Contact(string name, string email)
        {
            ViewBag.Result = $"Received: {name} - {email}";
            return View();
        }
        public IActionResult DbTest([FromServices] AppDbContext db)
        {
            try
            {
                var count = db.TestMessages.Count();
                return Content("DB Connected. Row count: " + count);
            }
            catch (Exception ex)
            {
                return Content("ERROR: " + ex.Message);
            }
        }
        public IActionResult DebugInfo([FromServices] IConfiguration config)
        {
            try
            {
                var conn = config.GetConnectionString("DefaultConnection");
                return Content("Connection String Loaded OK");
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }




    }
}
