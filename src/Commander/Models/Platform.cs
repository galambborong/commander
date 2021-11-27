using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Platform
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}