using shopBackEnd.ModelsDTO.Common;

namespace shopBackEnd.ModelsDTO.Request
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
