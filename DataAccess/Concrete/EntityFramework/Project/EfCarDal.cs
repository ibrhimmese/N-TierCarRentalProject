using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.Project;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete.Project;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Project
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SimpleContextDb>, ICarDal
    {
        private IList<CarDetailDto> CarDetailList()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from x in context.Cars
                             join y in context.Brands
                             on x.BrandId equals y.Id
                             join z in context.Colors
                             on x.ColorId equals z.Id
                             select new CarDetailDto
                             {
                                 CarId = x.Id,      
                                 BrandId = x.BrandId,
                                 BrandName = y.Name,
                                 ColorId = x.ColorId,
                                 ColorName = z.Name,
                                 ModelYear = x.ModelYear,
                                 Description = x.Description,
                                 DailyPrice = x.DailyPrice,
                                 FindeksScore = x.FindeksScore,
                                 MainImageUrl=(context.CarImages.Where(p=>p.CarId==x.Id && p.DefaultImage==true).Count()>0
                                              ? (context.CarImages.Where(p => p.CarId == x.Id && p.DefaultImage == true).Select(s=>s.ImagePath).FirstOrDefault())
                                              :null),
                                              
                                 Images =context.CarImages.Where(p=>p.CarId==x.Id).Select(s=>s.ImagePath).ToList()
                             };
                return result.ToList();
            }
        }



        private IList<DenemeDto> CarDetailListDeneme()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from x in context.Cars
                             join y in context.Brands
                             on x.BrandId equals y.Id
                             join z in context.Colors
                             on x.ColorId equals z.Id
                             select new DenemeDto
                             {
                                 CarId = x.Id,
                                 BrandId = x.BrandId,
                                 ColorId = x.ColorId,                             
                                 ModelYear = x.ModelYear,
                                 Description = x.Description,
                                 DailyPrice = x.DailyPrice,
                                 FindeksScore = x.FindeksScore,
                               
                             };
                return result.ToList();
            }
        }
        public IList<CarDetailDto> GetListCarDetail()
        {
            var result = CarDetailList();
            return result.ToList();
        }

        public IList<DenemeDto>GetListCarDetailDeneme()
        {
            var result = CarDetailListDeneme();
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailId(int id)
        {
            var result = CarDetailList().Where(p => p.CarId == id);
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailByBrandId(int brandId)
        {
            var result = CarDetailList().Where(c => c.BrandId == brandId);
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailByColorId(int colorId)
        {
            var result = CarDetailList().Where(c => c.ColorId == colorId);
            return result.ToList();
        }

        public IList<CarDetailDto> GetListCarDetailwithBrandIdAndColorId(int branId, int colorId)
        {
            var result = CarDetailList().Where(c => c.BrandId == branId && c.ColorId == colorId);
            return result.ToList();
        }
    }
}
