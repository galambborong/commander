using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Alias
    {
        [Key] 
        public int Id { get; set; }
        
        [Required] 
        public string CommandAlias { get; set; }

        [Required] 
        public int CommandId { get; set; }
        
        [ForeignKey("CommandId")] 
        public Command Command { get; set; }
    }
}