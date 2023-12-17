using Application.Services.Interfaces;
using Domain.Helpers;
using Domain.Models;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jWT;

        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jWT)
        {
            _userManager = userManager;
            _jWT = jWT.Value;
            _roleManager = roleManager;
        }
        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "This Email is already Registered!" };
            if (await _userManager.FindByEmailAsync(model.UserName) is not null)
                return new AuthModel { Message = "User name is already Registered!" };

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                return new AuthModel { Message = errors };
            }
            await _userManager.AddToRoleAsync(user, "User");
            var jwtSecurityToken = await CreateJwt(user);
            return new AuthModel
            {
                Email = user.Email,
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName
            };
        }
        public async Task<AuthModel> LoginAsync(Login model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "The Email or The Password is incorrect! please try Again";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwt(user);
            var roles = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = roles.ToList();
            return authModel;

        }
        public async Task<string> AddRoleAsync(AddRole model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null || !await _roleManager.RoleExistsAsync(model.RoleName))
                return "Invalid User ID Or Role";
            if (await _userManager.IsInRoleAsync(user, model.RoleName))
                return "User Is already Assigned to that Role";
            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            return result.Succeeded ? string.Empty : "Something went wrong";



        }
        private async Task<JwtSecurityToken> CreateJwt(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)

                roleClaims.Add(new Claim("roles", role));
            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim("uid",user.Id)
                }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWT.Issuer,
                audience: _jWT.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jWT.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
