using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessUsingEFCore.Repository
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("product_id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //automatic or auto-implemented property
        public int Id { get; set; }

        [Column("product_name", TypeName ="varchar(50)")]
        [Required]
        //property setter
        public string Name { get; set; } = string.Empty;

        [Column("product_price", TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Column("product_desc", TypeName = "varchar(MAX)")]        
        public string? Description { get; set; }

        [Column("product_make", TypeName = "varchar(50)")]
        [Required]
        public string Make { get; set; } = string.Empty;

        [Column("product_year", TypeName = "varchar(20)")]
        [Required]
        public string Year { get; set; } = DateTime.Now.Year.ToString();

        public Product() { }

        public Product(int id, string name, decimal price, string? description, string make, string year)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Make = make;
            Year = year;
        }
    }
}
