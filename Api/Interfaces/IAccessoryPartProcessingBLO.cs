using Api.DTOs;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IAccessoryPartProcessingBLO
    {
        Task<ProcessResponseDto> ProcessDefectiveComponent(ProcessRequestDto processRequest, string username);

    }
}