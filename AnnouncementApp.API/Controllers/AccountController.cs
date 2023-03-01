using AnnouncementApp.API.Models;
using AnnouncementApp.Base.Jwt;
using AnnouncementApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly JwtConfig jwtConfig;
        private readonly byte[] secret;
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.jwtConfig = jwtConfig.CurrentValue;
            this.secret = Encoding.ASCII.GetBytes(this.jwtConfig.Secret);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel input)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(input.Email, input.Password, true, false);
                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }
                var user = await userManager.FindByNameAsync(input.Email);
                return Ok(GetTokenResponse(user));
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Users
                {
                    UserName = input.Email,
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Department = input.Department,
                    EmailConfirmed = true,
                    
                    
                };

                var registerUser = await userManager.CreateAsync(newUser, input.Password);
                if (registerUser.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    var user = await userManager.FindByNameAsync(newUser.UserName);

                    return Ok(GetTokenResponse(user));
                }
                AddErrors(registerUser);
            }
            return BadRequest(ModelState);

        }

        private Task<Users> GetCurrentUserAsync()
        {
            return userManager.GetUserAsync(HttpContext.User);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("error", err.Description);
            }
        }
        private TokenResponse GetTokenResponse(Users user)
        {
            var token = GenerateAccessToken(user);
            TokenResponse result = new TokenResponse
            {
                AccessToken = token,
                ExpireTime = jwtConfig.AccessTokenExpiration * 60,   // as second
                Email = user.Email
            };
            return result;
        }

        private string GenerateAccessToken(Users user)
        {
            // Get claim value
            Claim[] claims = GetClaim(user);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
        private static Claim[] GetClaim(Users user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString()),
            };

            return claims;
        }
    }
}