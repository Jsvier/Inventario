using api_inventory.Model;
 
namespace web_api_inventory.repository
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}