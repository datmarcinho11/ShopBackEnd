using System.ComponentModel.DataAnnotations;

namespace shopBackEnd.ModelsDTO.Request
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal Sale_lPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { set; get; }

        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public DateTime DateCreated { set; get; }

        public string SeoAlias { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { set; get; }

    }
}
