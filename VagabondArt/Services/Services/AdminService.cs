using Repository.RepositoryInterfaces;
using Services.Interfaces;

namespace Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository m_AdminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
             m_AdminRepository = adminRepository;
        }

        public int Authenticate(string userName, string password)
        {
            var adminId = m_AdminRepository.Authenticate(userName, password);

            return adminId;
        }
    }
}