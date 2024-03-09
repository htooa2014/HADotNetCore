using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch3.HW.ATMapp.Models
{
    [Table("Tbl_Atm")]
    public class ATMModel
    {
        [Key]

        public int AtmId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string CardNumber { get; set; }

        public decimal Balance { get; set; }
    }
}
