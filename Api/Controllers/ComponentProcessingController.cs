using System.Threading.Tasks;
using Api.Constants;
using Api.DTOs;
using Api.Interfaces;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ComponentProcessingController : Controller
    {
        private readonly IIntegralPartProcessingBLO _integralPartProcessingBLO;
        private readonly IAccessoryPartProcessingBLO _accessoryPartProcessingBLO;
        private readonly ICompleteProcessingBLO _completeProcessingBLO;

        public ComponentProcessingController(IIntegralPartProcessingBLO integralPartProcessingBLO,
         IAccessoryPartProcessingBLO accessoryPartProcessingBLO,
         ICompleteProcessingBLO completeProcessingBLO)
        {
            _completeProcessingBLO = completeProcessingBLO;
            _accessoryPartProcessingBLO = accessoryPartProcessingBLO;
            _integralPartProcessingBLO = integralPartProcessingBLO;

        }

        [HttpPost("processDetail")]
        public async Task<ActionResult<ProcessResponseDto>> ProcessDetail(ProcessRequestDto processRequest)
        {
            var username = User.GetUserName();
            var result = new ProcessResponseDto();

            if (processRequest.DefectiveComponentType == ReturnOrderManagementConstants.Integral)
            {
                result = await _integralPartProcessingBLO.ProcessDefectiveComponent(processRequest, username);

            }
            else if (processRequest.DefectiveComponentType == ReturnOrderManagementConstants.Accessory)
            {
                result = await _accessoryPartProcessingBLO.ProcessDefectiveComponent(processRequest, username);
            }

            return Ok(result);

        }

        [HttpPost("completeProcessing")]
        public async Task<ActionResult<bool>> CompleteProcessing(PaymentDetailsDto paymentDetails)
        {
            var username = User.GetUserName();
            var result = await _completeProcessingBLO.SaveReturnRequest(paymentDetails, username);
            return Ok(result);
        }
    }
}