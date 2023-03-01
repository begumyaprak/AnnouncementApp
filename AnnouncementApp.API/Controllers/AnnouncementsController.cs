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
            private readonly IAnnouncementService announcementService;
            private readonly IMapper mapper;
            private readonly IUnitOfWork unitOfWork;

            public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper, IUnitOfWork unitOfWork)
            {
                this.announcementService = announcementService;
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
            }


            [HttpGet("GetAll")]
            public async Task<BaseResponse<List<AnnouncementsDto>>> GetAllAnnouncements()
            {
                try
                {

                    var result = announcementService.GetAll();
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
                    var result = announcementService.GetById(id);
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
                    announcementService.Add(announcementsDto);

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
                    announcementService.Update(id, announcementsDto);

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
                    announcementService.Delete(id);

                    return new BaseResponse<AnnouncementsDto>(true);


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }


            //[HttpGet("Get Announcement Detail ")]
            //public async Task<BaseResponse<AnnouncementsDto>> GetDetail(int id)
            //{
            //    try
            //    {

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}

        }
    
}
