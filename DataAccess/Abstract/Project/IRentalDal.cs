using Core.DataAccess;
using Entities.Concrete.Project;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Project
{
    public interface IRentalDal :IEntityRepository<Rental>
    {
        IList<RentalDetailDto> GetListRentalDetail();
        IList<RentalDetailDto> GetListRentalDetailByBrand(int brandId);
        IList<RentalDetailDto> GetListRentaDetailByColor(int colorId);
    }
}
