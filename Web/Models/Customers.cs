using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Customers
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("customer_name")]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(40)]
        [Column("cutomer_surname")]
        public string CustomerSurname { get; set; }

        [Required]
        [MaxLength(11)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("customer_account")]
        public int CustomerAccount { get; set; }
    }
}
