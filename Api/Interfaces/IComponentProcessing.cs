using Api.DTOs;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IComponentProcessing
    {
        Task<ProcessResponseDto> ProcessDefectiveComponent(ProcessRequestDto processRequest, string username);
    }
}