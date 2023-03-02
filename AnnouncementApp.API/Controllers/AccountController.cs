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
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtConfig _jwtConfig;
        private readonly byte[] _secret;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _jwtConfig = jwtConfig.CurrentValue;
            _secret = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel input)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(input.Email, input.Password, true, false);
                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }
                var user = await _userManager.FindByNameAsync(input.Email);
                return Ok(GetTokenResponse(user));
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = input.Email,
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    Department = input.Department,
                    EmailConfirmed = true,
                    
                    
                };

                var registerUser = await _userManager.CreateAsync(newUser, input.Password);
                if (registerUser.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    var user = await _userManager.FindByNameAsync(newUser.UserName);

                    return Ok(GetTokenResponse(user));
                }
                AddErrors(registerUser);
            }
            return BadRequest(ModelState);

        }

        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("error", err.Description);
            }
        }
        private TokenResponse GetTokenResponse(User user)
        {
            var token = GenerateAccessToken(user);
            TokenResponse result = new TokenResponse
            {
                AccessToken = token,
                ExpireTime = _jwtConfig.AccessTokenExpiration * 60,   // as second
                Email = user.Email
            };
            return result;
        }

        private string GenerateAccessToken(User user)
        {
            // Get claim value
            Claim[] claims = GetClaim(user);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                _jwtConfig.Issuer,
                shouldAddAudienceClaim ? _jwtConfig.Audience : string.Empty,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
        private static Claim[] GetClaim(User user)
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