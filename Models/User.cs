using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        
        [Timestamp]
        public byte[] CreatedAt { get; set; }
    }
}