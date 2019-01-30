using System.Linq;
using System.Web.Mvc;
using Event.Models;
using PagedList;

namespace Event.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private const int PageSize = 3;

        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var events = _context.Events.OrderBy(x => x.Name).ToPagedList(pageNumber, PageSize);
            return View(events);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}