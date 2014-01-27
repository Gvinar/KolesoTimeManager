namespace Koleso.Core.Models.TimePriceRule
{
    public class TimePriceRule : ITimePriceRule
    {
        public int MinuteFrom { get; set; }
        
        public int MinuteTo { get; set; }
        
        public decimal Price { get; set; }
    }
}
