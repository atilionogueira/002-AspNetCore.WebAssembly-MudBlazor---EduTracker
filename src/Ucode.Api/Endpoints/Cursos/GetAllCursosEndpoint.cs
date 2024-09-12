using Microsoft.AspNetCore.Mvc;
using Ucode.Api.Common.Api;
using Ucode.Core;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Curso;
using Ucode.Core.Responses;

namespace Ucode.Api.Endpoints.Cursos
{
    public class GetAllCursosEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
            .WithName("Curso: Get All")
            .WithSummary("Recuperando todos os curso")
            .WithDescription("Recuperando todos curso")
            .WithOrder(4)
            .Produces<PagedResponse<List<Curso>?>>();
        private static async Task<IResult> HandleAsync(
            ICursoHandler handler,
            [FromQuery]int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery]int pageSize = Configuration.DefaultPageSize )
        {
            var request = new GetAllCursoRequest
            {
                UserId = "test@balta.io",
                PageNumber = pageNumber,
                PageSize = pageNumber
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
