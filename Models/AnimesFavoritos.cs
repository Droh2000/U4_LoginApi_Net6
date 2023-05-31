using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class AnimesFavoritos
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; } //sirve de nexo con la entidad Usuario
        public int IdAnime { get; set; }

        // Propiedades de navegacion
        public Usuario Usuario { get; set; }
    }
}