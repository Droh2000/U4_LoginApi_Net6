using LoginApi.Dto;
using LoginApi.Models;
using AutoMapper;

namespace LoginApi.Utilidades
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            //Aquí van las reglas de mapeo <origen,destino>
            CreateMap<UsuarioCreacionDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Usuario, LoginUsuarioDTO>();// Para solo mostrar el email y password
        }
    }
}