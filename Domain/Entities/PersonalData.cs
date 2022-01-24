using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("PersonalData")]
    public class PersonalData
    {
        [Key]
        public int Id { get; set; } // Guid in the future
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pesel { get; set; }
        public bool SanitaryBook { get; set; }
        public string BankAccount { get; set; }
    }
}
