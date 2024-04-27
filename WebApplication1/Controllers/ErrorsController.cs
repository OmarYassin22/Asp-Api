using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.presentations.Errors;

namespace Talabat.presentations.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int code)
        {

            return NotFound(new ApiResponease(code));
        }
    }
}
