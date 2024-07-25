using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelController : Controller
    {
        private readonly Mydbcontext _dbcontext;

        public ModelController(Mydbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public IActionResult Post(Model request)
        {
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Brand = request.Brand,
                Name = request.Name,
                Year = request.Year
            };
            _dbcontext.Models.Add(model);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_dbcontext.Models);
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            Model model = _dbcontext.Models.FirstOrDefault(item => item.Id == id);
            if (model == null)
            {
                return BadRequest("Model not found");
            }
            _dbcontext.Models.Remove(model);
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpPut]

        public IActionResult Put(Guid id, Model request)
        {
            Model model = _dbcontext.Models.FirstOrDefault(item => item.Id == id);

            if (model == null)
            {
                return BadRequest("Model not found");
            }

            model.Brand = request.Brand;
            model.Name = request.Name;
            model.Year = request.Year;

            _dbcontext.SaveChanges();

            return Ok();
        }
    }
}
