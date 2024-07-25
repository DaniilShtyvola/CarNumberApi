using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly Mydbcontext _dbcontext;

        public CarController(Mydbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public IActionResult Post(Car request)
        {
            var car = new Car
            {
                VIN = request.VIN,
                Number = request.Number,
                ModelId = request.ModelId,
                ColorId = request.ColorId
            };
            _dbcontext.Cars.Add(car);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet]

        public IActionResult Get()
        {
            var cars = _dbcontext.Cars.Include(c => c.Model).Include(c => c.Color).ToList();
            return Ok(cars);
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            Car car = _dbcontext.Cars.FirstOrDefault(item => item.Id == id);
            if (car == null)
            {
                return BadRequest("Car not found");
            }
            _dbcontext.Cars.Remove(car);
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpPut]

        public IActionResult Put(Guid id, Car request)
        {
            Car car = _dbcontext.Cars.FirstOrDefault(item => item.Id == id);

            if (car == null)
            {
                return BadRequest("Car not found");
            }

            car.VIN = request.VIN;
            car.Number = request.Number;
            car.ModelId = request.ModelId;
            car.ColorId = request.ColorId;

            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
