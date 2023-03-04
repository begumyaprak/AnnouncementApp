using AnnouncementApp.API.Models;

namespace AnnouncementApp.UI.Services
{
    public interface IUserManagementService
    {
        public  Task Register(string firstName, string lastName, string email,
                          string password, string confirmPassword,
                          string department);

        public Task<TokenResponse> Login(string email, string password);
    }
}
