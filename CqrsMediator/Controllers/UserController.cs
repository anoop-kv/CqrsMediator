using CqrsMediator.Api.Commands;
using CqrsMediator.Api.Domain;
using CqrsMediator.Api.DTO;
using CqrsMediator.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;   
        }

        [HttpPost(Name = "Create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var result = await _mediator.Send(new CreateUserCommand
            {
                User = new User
                {
                    Id = Guid.NewGuid(),
                    Name = createUserDto.Name
                }
            });

            return Ok(result);
        }

        [HttpGet(Name = "Get")]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var result = await _mediator.Send(new GetUsersRequest());

            return Ok(result);
        }

        [HttpGet("{{id}}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUsersRequest());

            var user = result.SingleOrDefault(r => r.Id == id);
            
            return user  == null ? NotFound() : Ok(user);
        }
    }
}