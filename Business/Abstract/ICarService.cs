using Core.Utilities.Result.Abstract;
using Entities.Concrete.Project;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<IList<Car>> GetAll();
        IDataResult<IList<CarDetailDto>> GetCarListByBrandId(int brandId);
        IDataResult<IList<CarDetailDto>> GetCarListByColorId(int colorId);
        IDataResult<IList<CarDetailDto>> GetCarListWithBrandIdAndColorId(int brandId, int colorId);
        IDataResult<IList<CarDetailDto>> GetListCarDetail(); 
        IDataResult<IList<DenemeDto>> GetListCarDetailDeneme();
        IDataResult<IList<CarDetailDto>> GetListCarDetailId(int id);
        IDataResult<Car> Get(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
