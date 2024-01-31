using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Products
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("product_name")]
        public string ProductName { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("product_size")]
        public string ProductSize { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("type_of_paper")]
        public string PaperType { get; set; }

        [Required]
        [Column("product_amount")]
        public int ProductAmount { get; set; }

        [Required]
        [Column("product_price")]
        public float ProductPrice { get; set; }
    }
}
