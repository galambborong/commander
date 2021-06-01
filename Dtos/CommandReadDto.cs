using System.ComponentModel.DataAnnotations.Schema;
using Commander.Models;

namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        
        public string HowTo { get; set; }
        
        public string Line { get; set; }
        
        public bool AdminPrivilegesRequired { get; set; }

        public int PlatformId { get; set; }
        
    }
}