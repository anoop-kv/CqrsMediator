using CqrsMediator.Api.Domain;

namespace CqrsMediator.Api.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private static readonly Dictionary<Guid, User> Users = new();

        public IEnumerable<User> GetAll()
        {
            return Users.Select(u => u.Value);
        }

        public Guid Save(User user)
        {
            Users.Add(user.Id, user);

            return user.Id; 
        }
    }
}
