using Ucode.Core.Models;
using Ucode.Core.Requests.Modulo;
using Ucode.Core.Responses;

namespace Ucode.Core.Handlers
{
    public interface IModuloHandler
    {
        Task<Response<Modulo>>CreateAsync(CreateModuloRequest request);
        Task<Response<Modulo>>UpdatteAsync(UpdateModuloRequest request);
        Task<Response<Modulo>>DeleteAsync(DeleteModuloRequest request);
        Task<Response<Modulo>>GetByAsync(GetModuloByIdRequest request);
        Task<Response<List<Modulo>>>GetAllAsync(GetAllModuloRequest request);
    }
}
