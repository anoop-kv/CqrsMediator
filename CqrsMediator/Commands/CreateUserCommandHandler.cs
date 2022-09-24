using CqrsMediator.Api.Infrastructure;
using MediatR;

namespace CqrsMediator.Api.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(userRepository.Save(request.User));
        }
    }
}
