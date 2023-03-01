using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.Models;
using AnnouncementApp.Data.Repositories;
using AnnouncementApp.Data.UOW;
using AnnouncementApp.DTO;
using AnnouncementApp.Service.Abstract;
using AnnouncementApp.Service.Base;
using AutoMapper;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Concrete
{
    public class AnnouncementService : BaseService<AnnouncementsDto, Announcements>, IAnnouncementService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Announcements> repository;
        private readonly IMapper mapper;
        public AnnouncementService(IUnitOfWork unitOfWork, IRepository<Announcements> repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {

            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }
    }


    //public BaseResponse<AnnouncementsDto> GetDetail(int id)
    //{
    //    var entity = repository.GetById(id);
    //    var result = mapper.Map<TEntity, Dto>(entity);

    //    return new BaseResponse<AnnouncementsDto>(result);
    //}
}
