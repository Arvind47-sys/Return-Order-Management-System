using api.Repository.IRepository;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Api.BLOs
{

    public class IntegralPartProcessingBLO : IComponentProcessing, IIntegralPartProcessingBLO
    {
        private readonly IMapper _mapper;
        private readonly IProcessRequestAndResponseRepository _processRequestAndResponseRepository;
        private readonly IUserRepository _userRepository;

        public IntegralPartProcessingBLO(IProcessRequestAndResponseRepository processRequestAndResponseRepository,
        IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _processRequestAndResponseRepository = processRequestAndResponseRepository;
            _mapper = mapper;
        }

        public async Task<ProcessResponseDto> ProcessDefectiveComponent(ProcessRequestDto processRequestDto, string username)
        {
            var userId = await _userRepository.GetUserId(username);
            var processRequest = _mapper.Map<ProcessRequest>(processRequestDto);
            ProcessResponseDto processResponseResult = new ProcessResponseDto();
            processRequest.AppUserId = userId;
            if (userId != 0)
            {
                if (processRequestDto.Id == 0)
                {
                    await _processRequestAndResponseRepository.CreateNewProcessesRequest(processRequest);
                    processResponseResult = ComputeProcessResponse(processRequest);
                }
                else
                {
                    await _processRequestAndResponseRepository.UpdateProcessRequest(processRequest);
                    processResponseResult = ComputeProcessResponse(processRequest);
                }
            }
            return processResponseResult;

        }

        private ProcessResponseDto ComputeProcessResponse(ProcessRequest processRequest)
        {
            {
                ProcessResponseDto processResponse = new ProcessResponseDto();
                processResponse = new ProcessResponseDto
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
}