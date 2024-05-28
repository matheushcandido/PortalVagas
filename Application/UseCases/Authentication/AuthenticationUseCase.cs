using Core.Entities;
using Core.RepositoriesInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Application.UseCases.Authentication
{
    public class AuthenticationUseCase : IAuthenticationUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationUseCase(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<UseCaseResponse<string>> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return UseCaseResponse<string>.Fail("Pedido é inválido", HttpStatusCode.BadRequest);
            }

            var user = await _repository.GetUserByEmail(request.Email);
            if (user == null || !user.Password.Equals(request.Password))
            {
                return UseCaseResponse<string>.Fail("Credenciais inválidas.", HttpStatusCode.Unauthorized);
            }

            var token = GenerateJWTToken(user);
            return UseCaseResponse<string>.Success(token);
        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}