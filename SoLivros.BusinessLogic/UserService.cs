using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoLivros.BusinessLogic
{
    using SoLivros.Abstraction.BusinessLogic;
    using SoLivros.Domain.DTO.User;
    using SoLivros.Domain.Infrastructure;
    using SoLivros.Domain.Models;

    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory;

        public UserService(
              UserManager<User> userManager
            , SignInManager<User> signInManager
            , IConfiguration configuration
            , IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory
        )
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.userClaimsPrincipalFactory = userClaimsPrincipalFactory ?? throw new ArgumentNullException(nameof(userClaimsPrincipalFactory));
        }

        public async Task<TokenDTO> CriarConta(RegisterUserRequest req)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(req.Nome)) throw new SoLivrosException("O nome é obrigatório.");
                if(string.IsNullOrWhiteSpace(req.Email)) throw new SoLivrosException("O email é obrigatório.");
                if(string.IsNullOrWhiteSpace(req.Senha)) throw new SoLivrosException("A senha é obrigatória.");

                var user = await userManager.FindByNameAsync(req.Email);

                if (user != null) throw new SoLivrosException("O usuário já está cadastrado");

                user = new User()
                {
                    UserName = req.Nome,
                    Email = req.Email
                };

                var result = await userManager.CreateAsync(user, req.Senha);

                if (!result.Succeeded) throw new SoLivrosException("Erro ao criar usuário");

                var appUser = await userManager.Users
                        .FirstOrDefaultAsync((u) => u.NormalizedUserName.Equals(req.Nome.ToUpper()));

                var token = GerateToken(appUser);

                return new TokenDTO()
                {
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new SoLivrosException("Erro ao criar conta.", ex);
            }
        }

        public async Task<TokenDTO> FazerLogin(LoginRequest req)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(req.Email);

                if (user == null || await userManager.IsLockedOutAsync(user)) throw new SoLivrosException("Erro ao efetuar login.");

                if (!await userManager.CheckPasswordAsync(user, req.Senha)) throw new SoLivrosException("Login ou Senha incorreto.");

                var principal = await userClaimsPrincipalFactory.CreateAsync(user);

                var result = await signInManager.CheckPasswordSignInAsync(user, req.Senha, true);

                if (!result.Succeeded) throw new SoLivrosException("Erro ao efetuar login.");

                return new TokenDTO()
                {
                    Token = GerateToken(user)
                };
            }
            catch (Exception ex)
            {
                throw new SoLivrosException("Erro ao efetuar login.", ex);
            }
        }

        private string GerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
