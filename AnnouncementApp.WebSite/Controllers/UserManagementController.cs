using AnnouncementApp.API;
using AnnouncementApp.API.Models;
using AnnouncementApp.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.UI.Controllers
{
    public class UserManagementController : Controller
    {

        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel();

            return View("Register", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost(RegisterViewModel viewModel)
        {
           
            await _userManagementService.Register(viewModel.FirstName, viewModel.LastName,
                                                viewModel.Email, viewModel.Password,
                                                viewModel.ConfirmPassword, viewModel.Department);

            return RedirectToAction("Index");
        }
        [HttpPost]
        [ActionName("LoginPost")]
        public async Task<IActionResult> LoginPost(LoginModel model)
        {
            var tokenResponse = await _userManagementService
                                .Login(model.Email, model.Password);
            Response.Cookies.Append(
                Constant.XAccessToken,
                tokenResponse.AccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
            return RedirectToAction("Index", "Feed");
        }
    }
}
