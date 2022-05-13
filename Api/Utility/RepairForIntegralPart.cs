using Api.DTOs;
using System;

namespace Api.Utility
{
    public class RepairForIntegralPart
    {
        public static ProcessResponseDto RepairCost(ProcessRequestDto processRequest)
        {
            var processResponse = new ProcessResponseDto
            {
                RequestId = processRequest.Id,
                DateOfDelivery = DateTime.Now.AddDays(2),
                ProcessingCharge = 300,
                PackagingAndDeliveryCharge = (50 + 100 + 50) * processRequest.Quantity
            };
            return processResponse;
        }
    }
}