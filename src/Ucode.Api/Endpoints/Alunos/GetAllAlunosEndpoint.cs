using Microsoft.AspNetCore.Mvc;
using Ucode.Api.Common.Api;
using Ucode.Core;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Alunos;
using Ucode.Core.Responses;

namespace Ucode.Api.Endpoints.Alunos
{
    public class GetAllAlunosEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
              .WithName("Alunos: Get Al ")
              .WithSummary("Recupera todo os alunos")
              .WithDescription("Recupera todo os alunos")
              .WithOrder(5)
              .Produces<PagedResponse<List<Aluno>?>>();

        private static async Task<IResult> HandleAsync(
            IAlunoHandler handler,
            [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery]int pageSizer = Configuration.DefaultPageSize)
           
        {
            var request = new GetAllAlunoRequest
            {
                UserId = "test@balta.io",
                PageNumber = pageNumber,
                PageSize = pageSizer
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
