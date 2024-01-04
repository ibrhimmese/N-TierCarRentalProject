using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Project
{
    public class CarImage
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }      
        public bool DefaultImage { get; set; }      
       

      
    }
}
