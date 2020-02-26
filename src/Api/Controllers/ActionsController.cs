using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteQualyteam.Application.Actions.Commands.CreateAction;
using TesteQualyteam.Application.NonConformities.Commands.CreateNonConformity;

namespace TesteQualyteam.Api.Controllers
{
    public class ActionsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateActionCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}