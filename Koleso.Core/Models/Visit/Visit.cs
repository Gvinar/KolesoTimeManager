using System;

namespace Koleso.Core.Models.Visit
{
    public class Visit : IVisit
    {
        public int Id { get; set; }
        
        public string CardId { get; set; }
        
        public DateTime EntranceTime { get; set; }
        
        public DateTime? ExitTime { get; set; }
        
        public bool IsOnline { get; set; }
    }
}
