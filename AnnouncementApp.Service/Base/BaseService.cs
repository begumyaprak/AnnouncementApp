
using AnnouncementApp.Base.Response;
using AnnouncementApp.Data.Repositories;
using AnnouncementApp.Data.UOW;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Base
{
    public class BaseService<Dto,TEntity> : IBaseService<Dto,TEntity> where TEntity : class where Dto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public Dto GetById(int id)
        {
            var entity = _repository.GetById(id);
            var result = _mapper.Map<TEntity,Dto>(entity);

            return (result);
        } 

        public List<Dto> GetAll()
        {
            var entity = _repository.GetAll();
            var result = _mapper.Map<List<TEntity>,List<Dto>>(entity);

            return (result);
        }

        public BaseResponse<Dto> Add(Dto DtoEntity)
        {

            var entity = _mapper.Map<Dto,TEntity>(DtoEntity);

             _repository.Add(entity);
             _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Dto>(DtoEntity);
        }

        public BaseResponse<Dto> Update(int id,Dto DtoEntity)
        {
            var tempEntity =  _repository.GetById(id);

            var entity = _mapper.Map<Dto,TEntity>(DtoEntity, tempEntity); 

            _repository.Update(entity);

            _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Dto>(DtoEntity);
        }

        public BaseResponse<Dto> Delete(int id)
        {

            var tempEntity =  _repository.GetById(id);

            var entity = _mapper.Map<TEntity ,Dto>(tempEntity);

            _repository.Delete(tempEntity);
            _unitOfWork.SaveChangesAsync();

            return new BaseResponse<Dto>(entity);


        }

        
    }

}
