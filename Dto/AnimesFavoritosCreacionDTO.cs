namespace LoginApi.Dto
{
    public class AnimesFavoritosCreacionDTO
    {
        public int IdAnime { get; set; }

        // la propiedad UsuarioId no se incluye porque ésta irá incluída en la ruta del controlador
    }
}