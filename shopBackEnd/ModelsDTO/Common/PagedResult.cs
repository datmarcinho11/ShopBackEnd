using shopBackEnd.ModelsDTO.Common;

namespace shopBackEnd.ModelsDTO.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}
