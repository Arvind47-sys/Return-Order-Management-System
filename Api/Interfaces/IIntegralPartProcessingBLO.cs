using Api.DTOs;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IIntegralPartProcessingBLO
    {
        Task<ProcessResponseDto> ProcessDefectiveComponent(ProcessRequestDto processRequest, string username);
    }
}