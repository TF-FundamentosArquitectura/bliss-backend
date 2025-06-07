// Domain/Specialists/Specialist.cs
namespace Bliss.API.Domain.Specialists
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}