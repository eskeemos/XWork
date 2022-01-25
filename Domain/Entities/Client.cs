namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual PersonalData? PersonalData { get; set; }
        public virtual Location? Location { get; set; }
    }
}
