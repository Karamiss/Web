using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Accounts
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(35)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [MaxLength(35)]
        [Column("pass")]
        public string Password { get; set; }

    }
}
