using Business.Abstract;
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
    public class FindeksServiceManager : IFindeksService
    {
        IFindeksServiceDal _findeksServiceDal;

        public FindeksServiceManager(IFindeksServiceDal findeksServiceDal)
        {
            _findeksServiceDal = findeksServiceDal;
        }

        public IResult Add(FindeksService findeksService)
        {
            _findeksServiceDal.Add(findeksService);
            return new SuccessResult();
        }

        public IDataResult<FindeksService> GetFindeks(int customerId)
        {
            return new SuccessDataResult<FindeksService>(_findeksServiceDal.Get(f => f.CustomerId == customerId));
        }
    }
}
