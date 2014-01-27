namespace Koleso.Persistence.Models
{
    public class DbTimePriceRule
    {
        public int MinuteFrom { get; set; }
        
        public int MinuteTo { get; set; }
        
        public decimal Price { get; set; }
    }
}
