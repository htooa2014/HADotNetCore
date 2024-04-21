using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch3.LoginApp.Models
{
    [Table("Tbl_Login")]
    public class LoginModel
    {
        [Key]
        public int LoginID {  get; set; }
        public string UserID { get; set; }

        public string SessionID { get; set; }

        public DateTime SessionExpired { get; set; }
    }
}
