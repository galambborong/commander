using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commander.Models
{
    public class Alias
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CommandAlias { get; set; }

        [Required]
        public Guid CommandId { get; set; }

        [ForeignKey("CommandId")]
        public Command Command { get; set; }
    }
}