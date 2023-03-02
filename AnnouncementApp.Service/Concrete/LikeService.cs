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
    public class LikeService : BaseService<LikeDto,Like> , ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Like> _repository;
        private readonly IMapper _mapper;
        public LikeService(IUnitOfWork unitOfWork, IRepository<Like> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {

            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
