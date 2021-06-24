using System;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("/api/commands/{id}/alias")]
    [ApiController]
    public class AliasesController : ControllerBase
    {
        private readonly IAliasesRepo _aliasesRepo;
        private readonly IMapper _mapper;

        public AliasesController(IAliasesRepo aliasesRepo, IMapper mapper)
        {
            _mapper = mapper;
            _aliasesRepo = aliasesRepo;
        }
        
        [HttpGet]
        public ActionResult<AliasReadDto> GetAliasByCommandId(int id)
        {
            var aliasItems = _aliasesRepo.GetAliasByCommandId(id);
            var mappedAliasItem = _mapper.Map<AliasReadDto>(aliasItems);
            
            return Ok(mappedAliasItem);
        }
    }
}