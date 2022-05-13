using Api.DTOs;
using System;

namespace Api.Utility
{
    public class ReplacementForAccessoryPart
    {
        public static ProcessResponseDto ReplacementCost(ProcessRequestDto processRequest)
        {
            var processResponse = new ProcessResponseDto
            {
                RequestId = processRequest.Id,
                DateOfDelivery = DateTime.Now.AddDays(5),
                ProcessingCharge = 500,
                PackagingAndDeliveryCharge = (100 + 200 + 50) * processRequest.Quantity
            };
            return processResponse;
        }
    }
}