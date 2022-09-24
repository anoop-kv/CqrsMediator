using CqrsMediator.Api.DTO;
using MediatR;

namespace CqrsMediator.Api.Queries
{
    public class GetUsersRequest : IRequest<IEnumerable<UserDto>>
    {
    }
}
