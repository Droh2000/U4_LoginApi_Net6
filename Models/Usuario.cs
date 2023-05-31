using System.ComponentModel.DataAnnotations;

namespace LoginApi.Models
{
    public class Usuario
    {
        // Las priedades de la clase son los campos de la tabla de la BD
        [Key]
        public int Id { get; set; }
        [StringLength(20,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string? Nombre { get; set; } 
        [StringLength(25,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string? ApellidoPaterno { get; set; }
        [StringLength(25,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string? ApellidoMaterno { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }

        //Propiedades de navegación
        public List<AnimesFavoritos> AnimesFavoritos { get; set; }
    }
}