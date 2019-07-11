namespace web_api_inventory.repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();
    }
}