﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;
using TesteQualyteam.Application.NonConformities.Commands.UpdateNonConformityStatus;
using TesteQualyteam.Application.NonConformities.Queries.GetNonConformity;
using TesteQualyteam.Application.TodoItems.Commands.CreateTodoItem;
using TesteQualyteam.Application.TodoItems.Commands.UpdateTodoItem;
using TesteQualyteam.Domain.Enums;

namespace TesteQualyteam.Api.Controllers
{
    public class NonConformitiesController : ApiController
    {
        [HttpGet("{id}")]
        public async Task<NonConformityDto> Get(int id)
        {
            return await Mediator.Send(new GetNonConformityQuery {Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateNonConformityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateNonConformityStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            if (command.Status == (int) NonConformityStatus.Ineffective)
            {
                var nonConformity = await Mediator.Send(new GetNonConformityQuery {Id = id});

                var createNonConformityCommand = new CreateNonConformityCommand
                {
                    Description = nonConformity.Description
                };


            }

            return NoContent();
        }
    }
}