using Business.Abstract;
using Business.Concrete.Messages;
using Business.Repositories.UserRepository.Constans;
using Business.Utilities.File;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Caching;
using Core.Aspect.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract.Project;
using Entities.Concrete;
using Entities.Concrete.Project;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileService _fileService;

        public CarImageManager(ICarImageDal carImageDal, IFileService fileService)
        {
            _carImageDal = carImageDal;
            _fileService = fileService;
        }

        // [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(CarImageDto carImageDto)
        {
            foreach (var image in carImageDto.Images)
            {
                IResult result = BusinessRules.Run(
               CheckIfImageExtensionsAllow(image.FileName),
               CheckIfImagesIsLessThanOneMb(image.Length)
              );

                if (result == null)
                {

                    string fileName = _fileService.FileSaveToServer(image, "./Content/CarImages/");
                    CarImage carImage = new CarImage()
                    {
                        Id = 0,
                        ImagePath = fileName,
                        CarId = carImageDto.CarId,
                        DefaultImage=false
                       
                    };

                    _carImageDal.Add(carImage);
                }

            }
           
            return new SuccessResult("Resim eklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult("Resim silindi");
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(x => x.CarId == carImageId));
        }

        public IDataResult<IList<CarImage>> GetAll()
        {
            return new SuccessDataResult<IList<CarImage>>(_carImageDal.GetAll());
        }

        public IResult Update(CarImageUpdateDto carImageUpdateDto) 
        {

            IResult result = BusinessRules.Run(
                CheckIfImageExtensionsAllow(carImageUpdateDto.Image.FileName),
                CheckIfImagesIsLessThanOneMb(carImageUpdateDto.Image.Length)
               );

            if (result != null)
            {
                return result;
            }
            string path = @"./Content/CarImages/" + carImageUpdateDto.ImagePath;
            _fileService.FileDeleteToServer(path);
           

            string fileName = _fileService.FileSaveToServer(carImageUpdateDto.Image, "./Content/CarImages/");
            CarImage carImage = new CarImage()
            {
                Id = carImageUpdateDto.Id,
                ImagePath = fileName,
                CarId = carImageUpdateDto.CarId,
                DefaultImage=carImageUpdateDto.DefaultImage
            };


            _carImageDal.Update(carImage);
            return new SuccessResult("Resim güncellendi");
        }



        private IResult CheckIfImagesIsLessThanOneMb(long imgSize)
        {
            decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001);
            if (imgMbSize > 5)
            {
                return new ErrorResult("Resim boyutu 5mb dan büyük olamaz");
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageExtensionsAllow(string fileName)
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".ico" };
            if (!AllowFileExtensions.Contains(extension))
            {
                return new ErrorResult("Dosyalarınız yalnızca jpg, jpeg, gif, png, ico uzantılı olmalıdır.");
            }
            return new SuccessResult();
        }

        public IResult SetMainImage(int id)
        {
            var carImage=_carImageDal.Get(p=>p.Id== id);
            var carImages=_carImageDal.GetAll(p=>p.CarId==carImage.CarId);
            foreach (var item in carImages)
            {
                item.DefaultImage = false;
                _carImageDal.Update(item);
            }
            carImage.DefaultImage = true;
            _carImageDal.Update(carImage);
            return new SuccessResult("Default resim eklendi");
        }
    }

}
