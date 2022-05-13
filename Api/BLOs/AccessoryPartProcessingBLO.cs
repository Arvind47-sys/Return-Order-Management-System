using api.Repository.IRepository;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.BLOs
{
    public class AccessoryPartProcessingBLO : IComponentProcessing, IAccessoryPartProcessingBLO
    {
          private readonly IMapper _mapper;
        private readonly IProcessRequestAndResponseRepository _processRequestAndResponseRepository;
        private readonly IUserRepository _userRepository;

        public AccessoryPartProcessingBLO(IProcessRequestAndResponseRepository processRequestAndResponseRepository,
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
            ProcessResponseDto processResponse = new ProcessResponseDto();
            processResponse = new ProcessResponseDto
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