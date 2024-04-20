using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch3.MvcApp.Models
{
    [Table("Tbl_LocalGoldPrice")]
    public class LocalGoldPriceModel
    {
        [Key]
        public int LocalGoldPriceID { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }
    }
}
