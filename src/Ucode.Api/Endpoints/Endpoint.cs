using Ucode.Api.Common.Api;
using Ucode.Api.Endpoints.Alunos;

namespace Ucode.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoint(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");

            endpoints.MapGroup("v1/alunos")
                .WithTags("Alunos")
                //.RequireAuthorization()
                .MapEndpoint<CreateAlunoEndpoint>()
                .MapEndpoint<DeleteAlunoEndpoint>()
                .MapEndpoint<GetAlunoByIdEndpoint>()
                .MapEndpoint<GetAllAlunosEndpoint>()
                .MapEndpoint<UpdateAlunoEndpoint>();
        }

        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }    
    }
}
