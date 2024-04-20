namespace DotNetTrainingBatch3.MvcApp.Models
{
    public class LocalGoldPriceResponseModel
    {
        public List<Decimal> Series { get; set; }
        public List<int> Labels { get; set; }
    }
}
