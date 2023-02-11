namespace TheGreatesrApplication.Models.Requests
{
    public class CreateARequest
    {
        public int AnimalKindId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
