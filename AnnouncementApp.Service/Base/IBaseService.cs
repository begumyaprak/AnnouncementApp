using AnnouncementApp.Base.Response;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Service.Base
{
    public interface IBaseService<Dto, TEntity> where TEntity : class where Dto : class
    {
        BaseResponse<Dto> GetById(int id);
        BaseResponse<List<Dto>> GetAll();
        BaseResponse<Dto> Add(Dto DtoEntity);
        BaseResponse<Dto> Update(int id, Dto DtoEntity);
        BaseResponse<Dto> Delete(int id);
    }

}
