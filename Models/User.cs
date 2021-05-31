using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Commander.Models
{
    [Index(nameof(Username), IsUnique = true)]
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
    }
}