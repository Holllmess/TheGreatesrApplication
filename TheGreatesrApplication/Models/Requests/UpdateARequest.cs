namespace TheGreatesrApplication.Models.Requests
{
    public class UpdateARequest
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
