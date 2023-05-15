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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicatioDbContext _contex;
        private readonly IMapper _mapper;
        
        public UsuarioController(ApplicatioDbContext contex,IMapper mapper)
        {
            _contex=contex;
            _mapper=mapper;

        }

        // En el login solo vamos a comparar Email y Pass (No tiene caso obtener todo el Data del ususario)
        // GET: api/Usuario (Obtener todos los usuarios)
        [HttpGet]
        public async Task<ActionResult<List<LoginUsuarioDTO>>> GetUsuarios()
        {
            var usuarios = await _contex.Usuarios.ToListAsync();
            usuarios.ForEach(user => user.Password = EncryptDecryptManager.DecodeFrom64(user.Password));
            return _mapper.Map<List<LoginUsuarioDTO>>(usuarios);
        }

        [HttpGet("Completo")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetUsuariosFull()
        {
            var usuarios = await _contex.Usuarios.ToListAsync();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }       

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            var existe = await _contex.Usuarios.AnyAsync(x => x.Email == usuarioCreacionDTO.Email);
            if(existe)
                return BadRequest($"Ya existe un usuario con el correo {usuarioCreacionDTO.Email}"); 

            var usuario = _mapper.Map<Usuario>(usuarioCreacionDTO);
            usuario.Password = EncryptDecryptManager.EncodePasswordToBase64(usuario.Password);
            _contex.Usuarios.Add(usuario);
            await _contex.SaveChangesAsync();
            return Ok();
        }

    }
}
