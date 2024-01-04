using Core.Utilities.Result.Abstract;
using Entities.Concrete.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<FindeksService> GetFindeks(int customerId);
        IResult Add(FindeksService findeksService);
    }
}
