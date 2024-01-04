using Business.Abstract;
using Business.Concrete.Messages;
using Business.ValidationRules.FluentValidation;
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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(IsColorNameExsist(color));
            if (result != null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(ColorMessages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(ColorMessages.ColorDeleted);
        }

        public IDataResult<Color> Get(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(x => x.Id == colorId));
        }

        public IDataResult<IList<Color>> GetAll()
        {
            return new SuccessDataResult<IList<Color>>(_colorDal.GetAll());
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(ColorMessages.ColorUpdated);
        }

        public IResult IsColorNameExsist(Color color)
        {
            var result = _colorDal.GetAll(c => c.Name == color.Name).ToList();
            if (result.Count > 0)
            {
                return new ErrorResult(ColorMessages.ColorNameExsist);
            }
            return new SuccessResult();
        }
    }
}
