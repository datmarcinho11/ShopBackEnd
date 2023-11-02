
using shopBackEnd.ModelsDTO.Common;

namespace shopBackEnd.ModelsDTO.Request
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }


        public string? CategoryId { get; set; }
    }
}
