using AutoMapper;
using Commander.Dtos;

namespace Commander.Profiles
{
    public class AliasesProfile : Profile
    {
        public AliasesProfile()
        {
            CreateMap<AliasMidWayDto, AliasReadDto>();
        }
    }
}