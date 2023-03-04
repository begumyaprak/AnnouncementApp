using AnnouncementApp.API;
using AnnouncementApp.Data.Models;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.UI.Models;
using Azure;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AnnouncementApp.UI.Controllers
{
    public class FeedController : Controller
    {
        protected readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
       
        public FeedController(IFlurlClientFactory flurlClientFactory, IHttpContextAccessor httpContextAccessor )
        {
            _flurlClient = flurlClientFactory.Get("https://localhost:7164");
            _httpContextAccessor = httpContextAccessor;

            _flurlClient.BeforeCall(flurlCall =>
            {

                var token = _httpContextAccessor.HttpContext.Request
                                .Cookies[Constant.XAccessToken];
                if (!string.IsNullOrWhiteSpace(token))
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                }
                else
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
                }
            });


        }

        public async Task<IActionResult> Index()
        {
           
            var response = await _flurlClient.Request("/api/Announcements/GetAll")
                            .GetJsonAsync<List<AnnouncementDto>>();

            var announcementViewModel = new AnnouncementViewModel
            {

                Announcements =  response
            };

            return View(announcementViewModel);
        }

        public async Task<IActionResult> Detail()
        {
            var id = Convert.ToInt32(Request.RouteValues["id"]);


            var response = await "https://localhost:7164"
                       .AppendPathSegment($"/api/Announcements/{id}")
                       .GetJsonAsync<AnnouncementDto>();


            var announcementDetailViewModel = new AnnouncementDetailViewModel
            {

                SelectedAnnouncement = response
            };

            return View(announcementDetailViewModel);
        }


        

    }
}
