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
            try
            {
                await _userManagementService.Register(viewModel.FirstName, viewModel.LastName,
                                                viewModel.Email, viewModel.Password,
                                                viewModel.ConfirmPassword, viewModel.Department);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
           
            
        }
        [HttpPost]
        [ActionName("LoginPost")]
        public async Task<IActionResult> LoginPost(LoginModel model)
        {

            var tokenResponse = await _userManagementService
                            .Login(model.Email, model.Password);

            if (tokenResponse == null)
            {

                ModelState.AddModelError(string.Empty , "Invalid Login");
                return View("Index");

            }
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
