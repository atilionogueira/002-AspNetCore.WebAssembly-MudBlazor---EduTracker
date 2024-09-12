﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ucode.Api.Common.Api;
using Ucode.Core;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.ControleAluno;
using Ucode.Core.Responses;

namespace Ucode.Api.Endpoints.ControleAlunos
{
    public class GetControleAlunoByPeriodEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
             => app.MapGet("/", HandleAsync)
              .WithName("Controlde Alunos: Get Al ")
              .WithSummary("Recupera todo os controle de alunos")
              .WithDescription("Recupera todos os controle de alunos")
              .WithOrder(5)
              .Produces<PagedResponse<List<ControleAluno>?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IControleAlunoHandler handler,
            DateTime? startDate = null,
            DateTime? endDate = null,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSizer = Configuration.DefaultPageSize)

        {
            var request = new GetControleAlunoByPeriodRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSizer,
                StartDate = startDate,
                EndDate = endDate
                
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSucess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
