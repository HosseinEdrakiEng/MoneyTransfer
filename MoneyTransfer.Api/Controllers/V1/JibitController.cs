using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Api.Models;

namespace MoneyTransfer.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class JibitController : ControllerBase
    {
        public JibitController()
        {
            
        }

        [HttpPost("callback")]
        public async Task<IActionResult> CallBack(JibitCallBackRequestDto request, CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}
