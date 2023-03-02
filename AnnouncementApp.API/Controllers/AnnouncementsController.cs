using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AnnouncementApp.Service.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.API.Controllers
{
   
    
        [Route("api/[controller]")]
        [ApiController]
        public class AnnouncementsController : Controller
        {
            private readonly IAnnouncementService _announcementService;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper, IUnitOfWork unitOfWork)
            {
                _announcementService = announcementService;
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }


            [HttpGet("GetAll")]
            public async Task<BaseResponse<List<AnnouncementsDto>>> GetAllAnnouncements()
            {
                try
                {

                    var result = _announcementService.GetAll();
                    return result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            [HttpGet("GetById")]
            public async Task<BaseResponse<AnnouncementsDto>> GetAnnouncementById(int id)
            {
                try
                {
                    var result = _announcementService.GetById(id);
                    return result;

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }

            [HttpPost("Add Announcement")]
            public async Task<BaseResponse<AnnouncementsDto>> AddAnnouncement(AnnouncementsDto announcementsDto)
            {

                try
                {
                    _announcementService.Add(announcementsDto);

                    return new BaseResponse<AnnouncementsDto>(announcementsDto);



                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }



            [HttpPut("Update Announcement")]
            public async Task<BaseResponse<AnnouncementsDto>> UpdateAnnouncementy(AnnouncementsDto announcementsDto, int id)
            {

                try
                {
                    _announcementService.Update(id, announcementsDto);

                    return new BaseResponse<AnnouncementsDto>(announcementsDto);


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            [HttpDelete("Delete Announcement")]
            public async Task<BaseResponse<AnnouncementsDto>> DeleteAnnouncement(int id)
            {

                try
                {
                    _announcementService.Delete(id);

                    return new BaseResponse<AnnouncementsDto>(true);


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            [HttpGet("Get Announcement Detail ")]
            public async Task<BaseResponse<string>> GetDetail(int id)
            {
                try
                {
                     var result = _announcementService.GetDetail(id);

                    return result;

                }
                catch (Exception ex)
                {

                    throw ex;
                }

        }



    }
    
}
