using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopBackEnd.Models.DataModels
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; } = String.Empty;
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public int CategoryId { get; set; }

        public string SeoAlias { get; set; }
        public string Image { get; set; } = string.Empty;

        public decimal Price { set; get; }
        public decimal Sale_Price { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateUpdated { set; get; }
        public Category? Category { get; set; }

        ICollection<OrderDetail>? OrderDetails { get; set; }
        ICollection<ProductImage>? ProductImages { get; set; }

        ICollection<Cart>? Carts { get; set; }
    }
}
