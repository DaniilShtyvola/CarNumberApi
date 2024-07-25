using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Mydbcontext:DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options) { }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
