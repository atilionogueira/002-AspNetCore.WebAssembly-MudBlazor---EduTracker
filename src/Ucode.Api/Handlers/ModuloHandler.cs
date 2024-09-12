using Microsoft.EntityFrameworkCore;
using Ucode.Api.Data;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Modulo;
using Ucode.Core.Responses;

namespace Ucode.Api.Handlers
{
    public class ModuloHandler(AppDbContext context) : IModuloHandler

    {
        public async Task<PagedResponse<List<Modulo>?>> GetAllAsync(GetAllModuloRequest request)
        {
            try
            {
                var query = context
               .Modulos
               .AsNoTracking()
               .Where(x => x.UserId == request.UserId)
               .OrderBy(x => x.Nome);


                var modulo = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Modulo>?>(modulo, count, request.PageNumber, request.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Modulo>?>(null, 500, "Não foi possível recuperar o modulo");
            }
        }

        public async Task<Response<Modulo?>> GetByAsync(GetModuloByIdRequest request)
        {
            try
            {
                var modulo = await context
                    .Modulos
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return modulo is null
                    ? new Response<Modulo?>(null, 404, "Modulo não encontrada")
                    : new Response<Modulo?>(modulo);
            }
            catch
            {
                return new Response<Modulo?>(null, 500, "Não foi possível recuperar a modulo");
            }
        }



        public async Task<Response<Modulo?>> CreateAsync(CreateModuloRequest request)
        {
            try
            {
                var modulo = new Modulo
                {
                    UserId = request.UserId,
                    Nome = request.Nome,
                    Resumo = request.Resumo,
                    CursoId = request.CursoId
                };

                await context.Modulos.AddAsync(modulo);
                await context.SaveChangesAsync();

                return new Response<Modulo?>(modulo, 201, "Modulo criado com sucesso");

            }
            catch 
            {
                return new Response<Modulo?>(null, 500,"Não foi posível criar um modulo");               
            }
        }              

        public async Task<Response<Modulo?>> UpdateAsync(UpdateModuloRequest request)
        {
            try
            {
                var modulo = await context
                .Modulos
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (modulo is null)
                    return new Response<Modulo?>(null, 404, "Modulo não encontrado");

                modulo.CursoId = request.CursoId;
                modulo.Nome = request.Nome;
                modulo.Resumo = request.Resumo;

                context.Modulos.Update(modulo);
                await context.SaveChangesAsync();

                return new Response<Modulo?>(modulo, message: "Modulo atualizado com sucesso");
            }
            catch
            {
                return new Response<Modulo?>(null,500,"Não foi possível atualizar o modulo");
            }
        }

        public async Task<Response<Modulo?>> DeleteAsync(DeleteModuloRequest request)
        {
            try
            {
                var modulo = await context
                .Modulos
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (modulo is null)
                    return new Response<Modulo?>(null, 404, "Modulo não encontrado");

                context.Modulos.Remove(modulo);
                await context.SaveChangesAsync();

                return new Response<Modulo?>(modulo, message: "Modulo excluido com sucesso");

            }
            catch
            {
                return new Response<Modulo?>(null, 500,"Não foi possível excluir o modulo");
            }
                
        }

      
    }
}
