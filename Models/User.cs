using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}