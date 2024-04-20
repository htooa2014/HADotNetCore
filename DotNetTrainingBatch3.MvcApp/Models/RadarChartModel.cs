using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch3.MvcApp.Models
{
    [Table("Tbl_RadarChart")]
    public class RadarChartModel
    {
        [Key]
        public int RadarChartId { get; set; }
        public int Series1 { get; set; }
        public int Series2 { get; set; }
        public int Series3 { get; set; }
        public string Month {  get; set; }
    }
}
