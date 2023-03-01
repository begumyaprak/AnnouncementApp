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
    public class AnnouncementService : BaseService<AnnouncementsDto, Announcements>, IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Announcements> _repository;
        private readonly IMapper _mapper;
        public AnnouncementService(IUnitOfWork unitOfWork, IRepository<Announcements> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {

            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
    }
}
