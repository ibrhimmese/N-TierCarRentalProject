using Business.Abstract;
using Business.Concrete.Messages;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract.Project;
using Entities.Concrete.Project;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[ValidationAspect(typeof(CarValidator),Priority =1)]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(CarMessages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarMessages.CarDeleted);

        }

        public IDataResult<IList<Car>> GetAll()
        {
            return new SuccessDataResult<IList<Car>>(_carDal.GetAll().ToList());
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == carId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(CarMessages.CarUpdated);

        }

        public IDataResult<IList<CarDetailDto>> GetListCarDetail()
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetListCarDetail());
        }
        //
        public IDataResult<IList<CarDetailDto>> GetListCarDetailId(int id)
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetListCarDetailId(id));
        }
        //
        public IDataResult<IList<CarDetailDto>> GetCarListByBrandId(int brandId)
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetListCarDetailByBrandId(brandId));
        }

        public IDataResult<IList<CarDetailDto>> GetCarListByColorId(int colorId)
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetListCarDetailByColorId(colorId));
        }

        public IDataResult<IList<CarDetailDto>> GetCarListWithBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetListCarDetailwithBrandIdAndColorId(brandId, colorId));
        }

        public IDataResult<IList<DenemeDto>> GetListCarDetailDeneme()
        {
            return new SuccessDataResult<IList<DenemeDto>>(_carDal.GetListCarDetailDeneme());
        }
    }
}
