using Application.Abstraction.IService;
using Application.Models;
using Asp.Versioning;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MoneyTransfer.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace MoneyTransfer.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequestDto request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<TransferRequestModel>();
            var response = await _transferService.Transfer(model, cancellationToken);
            return StatusCode((int)response.Error.StatusCode, response);
        }

        [HttpGet("inquiry/{clientBatchId}")]
        public async Task<IActionResult> Inquiry([FromRoute, Required] string clientBatchId, CancellationToken cancellationToken)
        {
            var response = await _transferService.Inquiry(clientBatchId, cancellationToken);
            return StatusCode((int)response.Error.StatusCode, response);
        }

        [HttpPost("schedule-transfer")]
        public async Task<IActionResult> ScheduleTransfer([FromBody] ScheduleTransferRequestDto request, CancellationToken cancellationToken)
        {
            var model = request.Adapt<ScheduleTransferRequestModel>();
            var response = await _transferService.ScheduleTransfer(model, cancellationToken);
            return StatusCode((int)response.Error.StatusCode, response);
        }
    }
}
