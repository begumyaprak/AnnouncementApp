using AnnouncementApp.API;
using AnnouncementApp.API.Models;
using Azure;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

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


        public class ErrorResponse
        {
            public string Message { get; set; }
        }
        public async Task<TokenResponse> Login(string email, string password)
        {   

            var userLogin = new LoginModel
            {
                Email = email,
                Password = password
            };


            var result = await "https://localhost:7164/"
                   //.AllowAnyHttpStatus()
                   .AllowHttpStatus("400")
                   .AppendPathSegment("/api/Account/Login")
                   .PostJsonAsync(userLogin);
            
            if (result.StatusCode == 400)
            {
               
                return null;
            }

            result.ResponseMessage.EnsureSuccessStatusCode();

            return await result.GetJsonAsync<TokenResponse>();

            
        }

    }
}
