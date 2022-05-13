using System.Collections.Generic;

namespace Api.DTOs
{
    public class UserRequestDetailsDto
    {

        public IEnumerable<ProcessRequestDto> ProcessRequests { get; set; }
        public IEnumerable<ProcessResponseDto> ProcessResponses { get; set; }
    }
}