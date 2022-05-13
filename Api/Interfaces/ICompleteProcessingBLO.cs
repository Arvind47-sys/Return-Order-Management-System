using Api.DTOs;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ICompleteProcessingBLO
    {
        Task<bool> SaveReturnRequest(PaymentDetailsDto paymentDetails, string username);
    }
}