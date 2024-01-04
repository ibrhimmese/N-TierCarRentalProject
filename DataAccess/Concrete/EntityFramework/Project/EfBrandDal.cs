using Core.DataAccess.EntityFramework;
using DataAccess.Abstract.Project;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Project
{
    public class EfBrandDal :EfEntityRepositoryBase<Brand,SimpleContextDb>,IBrandDal
    {

    }
}
