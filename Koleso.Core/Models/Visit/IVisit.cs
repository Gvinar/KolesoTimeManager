using System;

namespace Koleso.Core.Models.Visit
{
    public interface IVisit
    {
        int Id { get; set; }

        string CardId { get; set; }
        
        DateTime EntranceTime { get; set; }
        
        DateTime? ExitTime { get; set; }
        
        bool IsOnline { get; set; }
    }
}
