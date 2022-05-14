using Api.DTOs;
using Api.Entities;
using System.Threading.Tasks;

namespace api.Repository.IRepository
{
    public interface IProcessRequestAndResponseRepository
    {
        Task CreateNewProcessesRequest(ProcessRequest processRequest);
        Task UpdateProcessRequest(ProcessRequest processRequest);
        Task DeleteProcessRequest(ProcessRequest processRequest);
        Task<bool> CreateNewProcessesResponse(ProcessResponse processResponse);
        UserRequestDetailsDto GetAllUserReturnRequests(int appUserId);

    }
}
