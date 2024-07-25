using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : Controller
    {
        private readonly Mydbcontext _dbcontext;

        public ColorController(Mydbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public IActionResult Post(Models.Color request)
        {
            var color = new Models.Color
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                HexCode = request.HexCode
            };
            _dbcontext.Colors.Add(color);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_dbcontext.Colors);
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            Models.Color color = _dbcontext.Colors.FirstOrDefault(item => item.Id == id);
            if (color == null)
            {
                return BadRequest("Color not found");
            }
            _dbcontext.Colors.Remove(color);
            _dbcontext.SaveChanges();

            return Ok();
        }

        [HttpPut]

        public IActionResult Put(Guid id, Models.Color request)
        {
            Models.Color color = _dbcontext.Colors.FirstOrDefault(item => item.Id == id);

            if (color == null)
            {
                return BadRequest("Color not found");
            }

            color.Name = request.Name;
            color.HexCode = request.HexCode;

            _dbcontext.SaveChanges();

            return Ok();
        }

    }
}
