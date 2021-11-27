using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public bool AdminPrivilegesRequired { get; set; }

        [Required]
        public Guid PlatformId { get; set; }

        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }
    }
}