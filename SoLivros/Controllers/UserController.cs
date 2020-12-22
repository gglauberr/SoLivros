using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SoLivros.API.Controllers
{
    using SoLivros.Abstraction.BusinessLogic;
    using SoLivros.Domain.DTO;
    using SoLivros.Domain.DTO.User;

    public class UserController : BaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(TokenResponse))]
        public async Task<IActionResult> CriarConta(RegisterUserRequest req)
        {
            var response = new TokenResponse();
            try
            {
                response.Data = await userService.CriarConta(req);
                response.Success = true;
                response.Message = "Conta criada com sucesso.";
            }
            catch(Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesDefaultResponseType(typeof(TokenResponse))]
        public async Task<IActionResult> FazerLogin(LoginRequest req)
        {
            var response = new TokenResponse();
            try
            {
                response.Data = await userService.FazerLogin(req);
                response.Success = true;
                response.Message = "Login efetuado com sucesso.";
            }
            catch(Exception ex)
            {
                response.MontaErro(ex);
            }
            return Result(response);
        }
    }
}
