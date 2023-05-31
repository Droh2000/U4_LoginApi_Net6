namespace LoginApi.Dto
{
    public class AnimesFavoritosDTO
    {
        
        public int Id { get; set; }
        public int IdAnime { get; set; }

        // la propiedad UsuarioId no se incluye porque ésta irá incluída en la ruta del controlador
        
    }
}