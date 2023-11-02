using shopBackEnd.ModelsDTO.Common;
using shopBackEnd.ModelsDTO.Request;
using shopBackEnd.ModelsDTO.Response;

namespace shopBackEnd.Repositories
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);

        Task<ProductViewModel> GetById(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
