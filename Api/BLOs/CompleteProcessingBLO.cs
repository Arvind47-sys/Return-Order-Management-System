using api.Repository.IRepository;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace Api.BLOs
{
    public class CompleteProcessingBLO : ICompleteProcessingBLO
    {
        private readonly IMapper _mapper;
        private readonly IProcessRequestAndResponseRepository _processRequestAndResponseRepository;
        private readonly IUserRepository _userRepository;

        public CompleteProcessingBLO(IProcessRequestAndResponseRepository processRequestAndResponseRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _processRequestAndResponseRepository = processRequestAndResponseRepository;
            _mapper = mapper;

        }
        public async Task<bool> SaveReturnRequest(PaymentDetailsDto paymentDetails, string username)
        {
            var userId = await _userRepository.GetUserId(username);
            var processResponseDto = paymentDetails.ProcessResponse;
            var processResponse = _mapper.Map<ProcessResponse>(processResponseDto);
            processResponse.AppUserId = userId;

            return await _processRequestAndResponseRepository.CreateNewProcessesResponse(processResponse);
        }

    }
}
