using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.Deploy_O_Mat.Web.Application.DockerService;
using com.b_velop.Deploy_O_Mat.Web.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace com.b_velop.Deploy_O_Mat.Web.API.Controllers
{
    public class DockerServiceController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<DockerService>> List()
            => await Mediator.Send(new List.Query());

        [HttpPost("create")]
        public async Task<ActionResult<Unit>> Create(
            Create.Command command)
            => await Mediator.Send(command);

        [HttpPost("remove")]
        public async Task<ActionResult<Unit>> Remove(
            Remove.Command command)
            => await Mediator.Send(command);
    }
}