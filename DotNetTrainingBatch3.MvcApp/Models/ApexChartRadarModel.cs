namespace DotNetTrainingBatch3.MvcApp.Models
{
    public class ApexChartRadarModel
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }

    public class ApexChartRadarResponseModel
    {
        public List<ApexChartRadarModel> Series { get; set; }
        public List<string> Labels { get; set; }
    }




}
