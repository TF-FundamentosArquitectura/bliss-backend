public class Specialist
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public Specialist() { }
    public Specialist(int serviceId, string name)
    {
        ServiceId = serviceId;
        Name = name;

    }

}
