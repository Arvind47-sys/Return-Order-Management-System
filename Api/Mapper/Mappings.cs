using Api.DTOs;
using Api.Entities;
using AutoMapper;

namespace api.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ProcessRequest, ProcessRequestDto>().ReverseMap();
            CreateMap<ProcessResponse, ProcessResponseDto>().ReverseMap();

        }
    }
}
