using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers.Base
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        IWebHostEnvironment _env;

        public ErrorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("error/{code}")]
        public IActionResult Error(int code)
        {
            var errorMsg = "";
            string? stackTrace = null;

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            if (context != null && context.Error != null)
            {
                var exception = context.Error;
                Response.StatusCode = code;

                if (_env.IsDevelopment())
                {
                    errorMsg = exception.Message;
                    stackTrace = exception.ToString();
                }
                else
                {
                    errorMsg = "Erro ao processar a requisição, tente novamente mais tarde. Caso o problema persista entre em contato com nosso suporte";
                }
            }

            if (string.IsNullOrEmpty(errorMsg))
            {
                System.Net.HttpStatusCode statusCode = (System.Net.HttpStatusCode)code;
                errorMsg = statusCode.ToString();
            }

            var response = new
            {
                Erros = new List<string> { errorMsg },
                Trace = stackTrace
            };

            return new JsonResult(response);
        }
    }
}
