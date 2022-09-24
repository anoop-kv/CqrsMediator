using CqrsMediator.Api.DTO;
using CqrsMediator.Api.Infrastructure;
using MediatR;

namespace CqrsMediator.Api.Queries
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, IEnumerable<UserDto>>
    {
        private readonly IUserRepository userRepository;

        public GetUsersRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<IEnumerable<UserDto>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(userRepository.GetAll().Select(m => new UserDto { Id = m.Id, Name = m.Name }));
        }
    }
}
