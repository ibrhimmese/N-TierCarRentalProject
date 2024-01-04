using Business.Abstract;
using Business.Concrete.Messages;
using Core.Aspect.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract.Project;
using Entities.Concrete.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[SecuredOperation("brand.add,admin")]
       // [ValidationAspect(typeof(BrandValidator), Priority = 1)]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(IsCheckNameExsist(brand));
            if (result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(BrandMessages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(BrandMessages.BrandDeleted);
        }

        public IDataResult<Brand> Get(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.Id == brandId));
        }

        public IDataResult<IList<Brand>> GetAll()
        {
            return new SuccessDataResult<IList<Brand>>(_brandDal.GetAll().ToList());
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(BrandMessages.BrandUpdated);
        }

        public IResult IsCheckNameExsist(Brand brand)
        {
            var result = _brandDal.GetAll(b => b.Name == brand.Name).ToList();
            if (result.Count > 0)
            {
                return new ErrorResult(BrandMessages.BrandNameExsist);
            }
            return new SuccessResult();
        }
    }
}
