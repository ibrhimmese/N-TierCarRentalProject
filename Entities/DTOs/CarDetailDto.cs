using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto 
    {
        public int CarId { get; set; }
        public string Description { get; set; } 
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int FindeksScore { get; set; }

        public string MainImageUrl { get; set; }
        public List<string> Images { get; set;}
    }
}
