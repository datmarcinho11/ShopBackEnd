using shopBackEnd.ModelsDTO.Common;
using shopBackEnd.ModelsDTO.Request;

namespace shopBackEnd.Repositories
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);
    }
}
