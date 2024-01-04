using Core.Utilities.Result.Abstract;
using Entities.Concrete.Project;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<IList<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Add(CarImageDto carImageDto);
        IResult SetMainImage(int id);
        IResult Update(CarImageUpdateDto carImageUpdateDto);
        IResult Delete(CarImage carImage);
    }
}
