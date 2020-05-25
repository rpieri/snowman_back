using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snowman.Tourist.Spots.Domain.Users.Commands;
using Snowman.Tourist.Spots.Shared.API.Controllers;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.ViewModels.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : BaseController<UserController>
    {
        public UserController(IMediatorHandler mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserViewModel viewModel) 
        {
            return await Execute<AddUserCommand, AddUserViewModel>(viewModel);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkResult();
        }
    }
}
