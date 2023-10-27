using System.ComponentModel.DataAnnotations;

namespace ErniTechnicalExamMonteagudoJeffrey.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
    }
}
