using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LikeController(ILikeService likeService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _likeService = likeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetAll")]
        public async Task<List<LikeDto>> GetAllLikes()
        {
            try
            {

                var result = _likeService.GetAll();
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpGet("GetById")]
        public async Task<LikeDto> GetAnnouncementById(int id)
        {
            try
            {
                var result = _likeService.GetById(id);
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPost("Add Like")]
        public async Task<BaseResponse<LikeDto>> AddLike(LikeDto likeDto)
        {

            try
            {
                _likeService.Add(likeDto);

                return new BaseResponse<LikeDto>(likeDto);



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        [HttpPut("Update Like")]
        public async Task<BaseResponse<LikeDto>> UpdateAnnouncementy(LikeDto likeDto, int id)
        {

            try
            {
                _likeService.Update(id,likeDto);

                return new BaseResponse<LikeDto>(likeDto);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("Delete Like")]
        public async Task<BaseResponse<LikeDto>> DeleteLike(int id)
        {

            try
            {
                _likeService.Delete(id);

                return new BaseResponse<LikeDto>(true);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
