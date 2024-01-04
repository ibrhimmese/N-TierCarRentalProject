using Business.Abstract;
using Entities.Concrete.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetListCarDetail();
            if (result.Success)
            {
                return Ok(result);
               
            }
            return BadRequest(result);
        }

        [HttpGet("getcar")]
        public IActionResult GetListCarDeteailDeneme()
        {
            var result = _carService.GetListCarDetailDeneme();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarlistbybrandid")]
        public IActionResult GetCarListByBrandId(int brandId)
        {
            var result = _carService.GetCarListByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getlistcardetailid")]
        public IActionResult GetListCarDetailId(int id)
        {
            var result = _carService.GetListCarDetailId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarlistbycolorid")]
        public IActionResult GetCarListByColorId(int colorId)
        {
            var result = _carService.GetCarListByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarlistwithbrandidandcolorid")]
        public IActionResult GetCarListwithBrandIdAndColorId(int brandId, int colorId)
        {
            var result = _carService.GetCarListWithBrandIdAndColorId(brandId, colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
