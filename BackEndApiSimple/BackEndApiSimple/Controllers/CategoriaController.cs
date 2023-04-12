using AutoMapper;
using BackEndApiSimple.Data;
using BackEndApiSimple.DTOs;
using BackEndApiSimple.Models;
using BackEndApiSimple.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApiSimple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CategoriaDTO>> GetAll()
        {
            List<CategoriaDTO> listaDto = new();
            var lista = await _categoriaService.GetList();
            listaDto = _mapper.Map<List<CategoriaDTO>>(lista);
            return listaDto;
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<CategoriaDTO> GetById(int id)
        {

            var categoria = await _categoriaService.Get(id);
            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return categoriaDto;
        } 
        [HttpPost]
        public async Task<int> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoria=_mapper.Map<Categoria>(categoriaDTO);
            int id = await _categoriaService.Insert(categoria);
            return id;
        }
        [HttpDelete]
        public async Task<int> DeleteById(int id)
        {
            var categoria = await _categoriaService.Get(id);
            return await _categoriaService.Delete(categoria);
        }

    }
}
