namespace Repository.RepositoryInterfaces
{
    public interface IAdminRepository
    {
        int Authenticate(string userName, string password);
    }
}
