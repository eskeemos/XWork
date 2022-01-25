namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
