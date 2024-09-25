﻿using Ucode.Api.Common.Api;
using Ucode.Api.Endpoints.Alunos;
using Ucode.Api.Endpoints.ControleAlunos;
using Ucode.Api.Endpoints.Cursos;
using Ucode.Api.Endpoints.Identity;
using Ucode.Api.Endpoints.Modulos;
using Ucode.Api.Models;


namespace Ucode.Api.Endpoints
{
    public static class Endpoint
    {
        public static void MapEndpoint(this WebApplication app)
        {
            var endpoints = app
                .MapGroup("");
              
            endpoints.MapGroup("/")
                .WithTags("Health Check")
                .MapGet("/", () => new { message = "OK" });

            endpoints.MapGroup("v1/alunos")
                .WithTags("Alunos")
                .RequireAuthorization()
                .MapEndpoint<CreateAlunoEndpoint>()
                .MapEndpoint<DeleteAlunoEndpoint>()
                .MapEndpoint<GetAlunoByIdEndpoint>()
                .MapEndpoint<GetAllAlunosEndpoint>()
                .MapEndpoint<UpdateAlunoEndpoint>();

            endpoints.MapGroup("v1/cursos")
               .WithTags("Cursos")
               .RequireAuthorization()
               .MapEndpoint<CreateCursoEndpoint>()
               .MapEndpoint<DeleteCursoEndpoint>()
               .MapEndpoint<GetCursoByIdEndpoint>()
               .MapEndpoint<GetAllCursosEndpoint>()
               .MapEndpoint<UpdateCursoEndpoint>();

            endpoints.MapGroup("v1/modulos")
              .WithTags("Modulos")
              .RequireAuthorization()
              .MapEndpoint<CreateModuloEndpoint>()
              .MapEndpoint<DeleteModuloEndpoint>()
              .MapEndpoint<GetModuloByIdEndpoint>()
              .MapEndpoint<GetAllModulosEndpoint>()
              .MapEndpoint<UpdateModuloEndpoit>();

            endpoints.MapGroup("v1/controlealuno")
             .WithTags("Controle Alunos")
             .RequireAuthorization()
             .MapEndpoint<CreateControleAlunoEndpoint>()
             .MapEndpoint<DeleteControleAlunoEndpoint>()
             .MapEndpoint<GetControleAlunoByIdEndpoint>()
             .MapEndpoint<GetControleAlunoByPeriodEndpoint>()
             .MapEndpoint<UpdateControleAlunoEndpoint>();

            endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>(); // E para utilizar todo o padrão do Identity

            endpoints.MapGroup("v1/identity")
           .WithTags("Identity")
           .MapEndpoint<LogoutEndpoint>()
           .MapEndpoint<GetRolesEndpoint>();

        }
        private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
            where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }    
    }
}
