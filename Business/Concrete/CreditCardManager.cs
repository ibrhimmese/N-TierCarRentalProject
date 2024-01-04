using Business.Abstract;
using Business.Concrete.Messages;
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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCartDal)
        {
            _creditCardDal = creditCartDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var results = _creditCardDal.GetAll(c => c.CustomerId == creditCard.CustomerId);
            foreach (var result in results)
            {
                _creditCardDal.Delete(result);
            }

            _creditCardDal.Add(creditCard);
            return new SuccessResult(CreditCardMessages.CreditCardAdded);
        }

        public IDataResult<IList<CreditCard>> GetAll()
        {
            return new SuccessDataResult<IList<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CustomerId == customerId));
        }

        public IResult Payment()
        {
            return new SuccessResult(CreditCardMessages.PaymentSuccessful);
        }
    }
}
