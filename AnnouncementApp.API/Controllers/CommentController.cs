using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.API.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(ICommentService commentService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _commentService = commentService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetAll")]
        public async Task<List<CommentDto>> GetAllComments()
        {
            try
            {

                var result = _commentService.GetAll();
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpGet("GetById")]
        public async Task<CommentDto> GetCommentById(int id)
        {
            try
            {
                var result = _commentService.GetById(id);
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPost("Add Comment")]
        public async Task<BaseResponse<CommentDto>> AddComment(CommentDto commentDto)
        {

            try
            {
                _commentService.Add(commentDto);

                return new BaseResponse<CommentDto>(commentDto);



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        [HttpPut("Update Comment")]
        public async Task<BaseResponse<CommentDto>> UpdateComment(CommentDto commentDto, int id)
        {

            try
            {
                _commentService.Update(id, commentDto);

                return new BaseResponse<CommentDto>(commentDto);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("Delete Comment")]
        public async Task<BaseResponse<CommentDto>> DeleteComment(int id)
        {

            try
            {
                _commentService.Delete(id);

                return new BaseResponse<CommentDto>(true);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("Get Comment Text ")]
        public async Task<BaseResponse<string>> GetCommentText(int id)
        {
            try
            {
                var result = _commentService.GetCommentText(id);

                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
