namespace WebApplication2.Models
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string VIN { get; set; }
        public string Number { get; set; }
        public Guid ModelId { get; set; }

        public Guid ColorId { get; set; }
    }
}
