using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTrainingBatch3.LoginApp.Models
{
    [Table("Tbl_User")]
    public class UserModel
    {
        [Key]
        public string UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; }


    }
}
