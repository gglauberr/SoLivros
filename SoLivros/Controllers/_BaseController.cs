using Microsoft.AspNetCore.Mvc;

namespace SoLivros.API.Controllers
{
    using SoLivros.Domain.DTO;

    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json" , additionalContentTypes: "application/xml")]
    [ProducesErrorResponseType(typeof(BaseResponse))]
    public class BaseController : ControllerBase
    {
        protected IActionResult Result(BaseResponse response)
        {
            if(response is null)
            {
                return BadRequest(new BaseResponse<string>()
                {
                    Message = "Não foi possível montar os resultados para a sua requisição.",
                    ErrorDetails = "API Controller error. No Response."
                });
            }

            return (response.Success ? Ok(response) : BadRequest(response) as IActionResult);
        }
    }
}
