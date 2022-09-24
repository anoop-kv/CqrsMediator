using CqrsMediator.Api.Domain;
using MediatR;

namespace CqrsMediator.Api.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public User User { get; set; }
    }
}
