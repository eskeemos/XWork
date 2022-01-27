namespace Domain.Entities
{
    public class ZusStatement
    {
        public int Id { get; set; }
        public bool IsStudent { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsRetired { get; set; }
        public bool IsPensioner { get; set; }
        public bool HasCompany { get; set; }
        public bool IsInsured { get; set; }
    }
}
