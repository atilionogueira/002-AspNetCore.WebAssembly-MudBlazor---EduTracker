using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Modulo;
using Ucode.Core.Responses;

namespace Ucode.Web.Handlers
{
    public class ModuloHandler : IModuloHandler
    {
        public Task<Response<Modulo?>> GetByAsync(GetModuloByIdRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<PagedResponse<List<Modulo>?>> GetAllAsync(GetAllModuloRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<Response<Modulo?>> CreateAsync(CreateModuloRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<Response<Modulo?>> UpdateAsync(UpdateModuloRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<Response<Modulo?>> DeleteAsync(DeleteModuloRequest request)
        {
            throw new NotImplementedException();
        }
                     
    }
}
