using Ucode.Api.Common.Api;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Curso;
using Ucode.Core.Responses;

namespace Ucode.Api.Endpoints.Cursos
{
    public class GetCursoByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
           => app.MapGet("/{id}", HandleAsync)
            .WithName("Curso: Get By Id")
            .WithSummary("Recuperar um curso")
            .WithDescription("Recuperar um curso")
            .WithOrder(4)
            .Produces<Response<Curso?>>();
        private static async Task<IResult> HandleAsync(
            ICursoHandler handler,
            long id)
        {
            var request = new GetCursoByIdRequest
            {
                UserId = "test@balta.io",
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
