using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Commander.Models;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {
        [Required] [MaxLength(250)] public string HowTo { get; set; }

        [Required] public string Line { get; set; }

        [Required] public bool AdminPrivilegesRequired { get; set; }

        [Required] public int PlatformId { get; set; }

        [ForeignKey("PlatformId")] public Platform Platform { get; set; }
    }
}