using CqrsMediator.Api.Domain;

namespace CqrsMediator.Api.Infrastructure
{
    public interface IUserRepository
    {
        Guid Save(User user);

        IEnumerable<User> GetAll();
    }
}
