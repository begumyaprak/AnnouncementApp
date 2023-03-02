using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.Models;
using AnnouncementApp.Data.Repositories;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AnnouncementApp.Service.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Concrete
{
    public class CommentService : BaseService<CommentDto,Comment>, ICommentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public CommentService(IUnitOfWork unitOfWork, IRepository<Comment> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {

            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public BaseResponse<string> GetCommentText(int id)
        {
            var commentEntity = _repository.GetById(id);

            var commentText = commentEntity.CommentText;

            return new BaseResponse<string> (commentText);


        }



    }
}
