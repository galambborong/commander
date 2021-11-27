using System;

namespace Commander.Dtos
{
    public class AliasMidWay
    {
        public Guid Id { get; set; }
        public string CommandAlias { get; set; }
        public string Command { get; set; }
        public Guid CommandId { get; set; }
    }
}