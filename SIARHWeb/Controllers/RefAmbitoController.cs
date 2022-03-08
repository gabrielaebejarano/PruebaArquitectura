
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SIARH.Aplication;
using SIARH.Aplication.DTOs;
using SIARH.Persistence;
using SIARH.Persistence.Models;
using SIARH.Persistence.UnitOfWork;
using SIARH.Persistence.Services;
using SIARH.Persistence.Services.Implements;

namespace SIARHWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefAmbitoController : ControllerBase
    {

        private readonly IRefAmbitoService refAmbitoService;
        private readonly IRefEscalafonService refEscalafonService;
        //private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RefAmbitoController(IMapper mapper, IRefAmbitoService refAmbitoService, IRefEscalafonService refEscalafonService)
        {                       
            this.mapper = mapper;
            this.refAmbitoService = refAmbitoService;
            this.refEscalafonService = refEscalafonService;
        }

        [HttpGet("ambitoGetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await refAmbitoService.All());
        }

        [HttpGet("{id:int}", Name = "GetAmbito")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await refAmbitoService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRefAmbitoRefEscalafon(totalDTO totalDTO)
        {
            if (ModelState.IsValid)
            {
                //RefEscalafon refEscalafon = mapper.Map<RefEscalafon>(totalDTO);
                //RefAmbito refAmbito = mapper.Map<RefAmbito>(totalDTO);

                RefEscalafon refEscalafon = new RefEscalafon();
                refEscalafon.IdEscalafon = totalDTO.IdEscalafon;
                refEscalafon.EscalafonDesc = totalDTO.EscalafonDesc;
                refEscalafon.IdGrupoNivel = totalDTO.IdGrupoNivel;
                refEscalafon.Nomenclatura = totalDTO.Nomenclatura;

                RefAmbito refAmbito = new RefAmbito();
                refAmbito.IdAmbito= totalDTO.IdAmbito;
                refAmbito.AmbitoDesc = totalDTO.AmbitoDesc;
                await refAmbitoService.Add(refAmbito);
                await refEscalafonService.Add(refEscalafon);
                //await unitOfWork.CompleteAsync();

                return CreatedAtRoute("GetAmbito", new { id = refAmbito.IdAmbito }, refAmbito);                
            }

            return new JsonResult("No se pudo completar la transaccion") { StatusCode = 500 };
        }

    }
}