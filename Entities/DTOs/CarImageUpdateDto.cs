using Entities.Concrete.Project;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageUpdateDto:CarImage
    {
        public IFormFile Image { get; set; }    
    }
}
