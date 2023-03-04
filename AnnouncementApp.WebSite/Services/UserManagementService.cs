using AnnouncementApp.API;
using AnnouncementApp.API.Models;
using Azure;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.UI.Services
{
    public class UserManagementService : IUserManagementService
    {

        public async Task Register(string firstName, string lastName, string email,
                           string password, string confirmPassword,
                           string department)
        {
            var registerViewModel = new RegisterViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Department = department
            };

            await "https://localhost:7164/"
                   .AppendPathSegment("/api/Account/Register")
                   .PostJsonAsync(registerViewModel);
        }

        public async Task<TokenResponse> Login(string email, string password)
        {
            var userLogin = new LoginModel
            {
                Email = email,
                Password = password
            };

            return await "https://localhost:7164/"
                     .AppendPathSegment("/api/Account/Login")
                     .PostJsonAsync(userLogin).ReceiveJson<TokenResponse>();
        }

    }
}
