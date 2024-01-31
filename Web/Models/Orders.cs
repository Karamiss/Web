using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Orders
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Column("product")]
        public int ProductInfo { get; set; }

        [Required]
        [Column("customer")]
        public int Customerinfo { get; set; }

        [Required]
        [Column("total_price")]
        public float TotalPrice { get; set; }

    }
}
