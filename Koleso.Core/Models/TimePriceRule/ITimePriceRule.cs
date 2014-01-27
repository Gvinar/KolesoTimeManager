namespace Koleso.Core.Models.TimePriceRule
{
    public interface ITimePriceRule
    {
        int MinuteFrom { get; set; }
        
        int MinuteTo { get; set; }
        
        decimal Price { get; set; }
    }
}
