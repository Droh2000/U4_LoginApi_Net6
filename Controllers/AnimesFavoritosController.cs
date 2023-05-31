using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginApi.Models;
using LoginApi.Dto;
using LoginApi.Data;
using AutoMapper;

// Aqui tenemos todos los metodos de la API
namespace LoginApi.Controllers
{
    [Route("api/usuarios/{usuarioId:int}/comentarios")]//Ojo con la ruta dependiente, desde aquí se obtiene el usuarioId
    [ApiController]
    public class AnimesFavoritosController : ControllerBase
    {
        private readonly ApplicatioDbContext _contex;
        private readonly IMapper _mapper;
        
        public AnimesFavoritosController(ApplicatioDbContext contex,IMapper mapper)
        {
            _contex=contex;
            _mapper=mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<AnimesFavoritosDTO>>> Get(int usuarioId)
        {
            var existeUsuario = await _contex.Usuarios.AnyAsync(x => x.Id == usuarioId);
    
            if (!existeUsuario)
                return NotFound("El usuario no existe");
    
            var animes = await _contex.AnimesFavoritos.Where(x => x.UsuarioId == usuarioId).ToListAsync();
    
            return _mapper.Map<List<AnimesFavoritosDTO>>(animes);
        }

        [HttpGet("existeAnime")]
        public async Task<ActionResult<bool>> GetExisteAnime(int usuarioId, int IdAnime)
        {
            var existeUsuario = await _contex.Usuarios.AnyAsync(x => x.Id == usuarioId);
    
            if (!existeUsuario)
                return NotFound("El usuario no existe");

            // Verificar si el usuario ya tienen agregado el Id animes
            var animes = await _contex.AnimesFavoritos.Where(x => x.UsuarioId == usuarioId).ToListAsync();
            var listaAnimes = _mapper.Map<List<AnimesFavoritosDTO>>(animes);

            foreach (var i in listaAnimes) { 
                if (i.IdAnime == IdAnime)
                    return true;
            }
            return false;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int usuarioId, AnimesFavoritosCreacionDTO animesFavoritosCreacionDTO)
        {
            var existeUsuario = await _contex.Usuarios.AnyAsync(x => x.Id == usuarioId);
            
            if (!existeUsuario)
                return NotFound("El usuario no existe");

            var anime = _mapper.Map<AnimesFavoritos>(animesFavoritosCreacionDTO);
            anime.UsuarioId = usuarioId;

            // Verificar si el usuario ya tienen agregado el Id animes
            var animes = await _contex.AnimesFavoritos.Where(x => x.UsuarioId == usuarioId).ToListAsync();
            if(animes != null){
                var listaAnimes = _mapper.Map<List<AnimesFavoritosDTO>>(animes);
                foreach (var i in listaAnimes) { 
                    if (i.IdAnime == anime.IdAnime)
                        return NotFound("El anime ya esta en favoritos");
                }
            }
    
            _contex.AnimesFavoritos.Add(anime);
            await _contex.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{animeid:int}")]
        public async Task<ActionResult> Delete(int animeid, int usuarioId)
        {
            //debo validar que el anime pertenezca al usuario especificado
            var existeAnime = await _contex.AnimesFavoritos.Where(x => x.UsuarioId == usuarioId).AnyAsync(x => x.IdAnime == animeid);

            if (!existeAnime)
                return NotFound("El anime no existe o no coincide con el usuario especificado");

            // Obtener el Primari key del AnimeID
            var animes = await _contex.AnimesFavoritos.Where(x => x.IdAnime == animeid).ToListAsync();
            var animeDato = _mapper.Map<List<AnimesFavoritosDTO>>(animes);

            var id = 0;
            foreach (var i in animeDato) { 
                id = i.Id;    
            }

            _contex.AnimesFavoritos.Remove(new AnimesFavoritos { Id = id });    
            await _contex.SaveChangesAsync();
            return NoContent();
        }
    }
}    