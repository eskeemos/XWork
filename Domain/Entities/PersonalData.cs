namespace Domain.Entities
{
    public class PersonalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Pesel { get; set; }
        public bool SanitaryBook { get; set; }
        public string BankAccount { get; set; }
    }
}
