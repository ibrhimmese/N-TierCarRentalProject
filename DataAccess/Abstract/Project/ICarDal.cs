using Core.DataAccess;
using Entities.Concrete.Project;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Project
{
    public interface ICarDal:IEntityRepository<Car>
    {
        IList<CarDetailDto> GetListCarDetail();
        IList<DenemeDto> GetListCarDetailDeneme();
        IList<CarDetailDto> GetListCarDetailId(int id);
        IList<CarDetailDto> GetListCarDetailByBrandId(int brandId);
        IList<CarDetailDto> GetListCarDetailByColorId(int colorId);
        IList<CarDetailDto> GetListCarDetailwithBrandIdAndColorId(int branId, int colorId);
    }
}
