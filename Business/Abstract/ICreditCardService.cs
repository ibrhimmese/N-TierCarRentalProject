using Core.Utilities.Result.Abstract;
using Entities.Concrete.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<IList<CreditCard>> GetAll();
        IDataResult<CreditCard> GetByCustomerId(int customerId);
        IResult Add(CreditCard creditCart);
        IResult Payment();
    }
}
