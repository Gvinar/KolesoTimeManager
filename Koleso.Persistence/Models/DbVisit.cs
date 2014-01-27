namespace Koleso.Persistence.Models
{
    using System;

    public class DbVisit
    {
        public int Id { get; set; }
        
        public string CardId { get; set; }
        
        public DateTime EntranceTime { get; set; }
        
        public DateTime? ExitTime { get; set; }
        
        public bool IsOnline { get; set; }
    }
}
