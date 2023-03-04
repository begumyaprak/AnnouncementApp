using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.UI.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
