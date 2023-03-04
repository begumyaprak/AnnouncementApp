using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AnnouncementApp.Service.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

            [Authorize]
            [HttpGet("GetAll")]
            public async Task<List<AnnouncementDto>> GetAllAnnouncements()
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


            //[Authorize]
            [HttpGet]
            [Route("{id}")]
            public async Task<AnnouncementDto>GetAnnouncementById(string id)
            {
                var intId = Convert.ToInt32(id);
                try
                {
                    var result = _announcementService.GetById(intId);
                    return result;

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }

            [HttpPost("AddAnnouncement")]
            public async Task<BaseResponse<AnnouncementDto>> AddAnnouncement(AnnouncementDto announcementsDto)
            {

                try
                {
                    _announcementService.Add(announcementsDto);

                    return new BaseResponse<AnnouncementDto>(announcementsDto);



                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }



            [HttpPut("UpdateAnnouncement")]
            public async Task<BaseResponse<AnnouncementDto>> UpdateAnnouncementy(AnnouncementDto announcementsDto, int id)
            {

                try
                {
                    _announcementService.Update(id, announcementsDto);

                    return new BaseResponse<AnnouncementDto>(announcementsDto);


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

            [HttpDelete("DeleteAnnouncement")]
            public async Task<BaseResponse<AnnouncementDto>> DeleteAnnouncement(int id)
            {

                try
                {
                    _announcementService.Delete(id);

                    return new BaseResponse<AnnouncementDto>(true);


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

           
            }




    }
    

