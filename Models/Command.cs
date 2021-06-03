using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper.QueryableExtensions;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        [Required]
        public string Line { get; set; }

        [Required]
        public bool AdminPrivilegesRequired { get; set; }

        [Required]
        public int PlatformId { get; set; }
        
        [ForeignKey("PlatformId")] 
        public Platform Platform { get; set; }
    }

    [NotMapped]
    public class ReturnCommand
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
        public bool AdminPrivilegesRequired { get; set; }
    }
}