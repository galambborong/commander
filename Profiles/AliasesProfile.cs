using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles
{
    public class AliasesProfile : Profile
    {
        public AliasesProfile()
        {
            CreateMap<Alias, AliasReadDto>();
        }
    }
}