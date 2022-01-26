using System;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int PersonalDataId { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
