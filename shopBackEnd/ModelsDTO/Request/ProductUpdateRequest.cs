namespace shopBackEnd.ModelsDTO.Request

{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int ViewCount { set; get; }

        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public DateTime DateUpdated { set; get; }

        public string SeoAlias { get; set; }
        public int CategoryId { set; get; }


        public IFormFile? Image { get; set; }
    }
}
