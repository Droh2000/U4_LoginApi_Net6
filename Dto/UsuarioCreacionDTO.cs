using System.ComponentModel.DataAnnotations;

namespace LoginApi.Dto
{
    public class UsuarioCreacionDTO
    {
        [Required]
        [StringLength(20,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string Nombre { get; set; }
        [Required] 
        [StringLength(25,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(25,ErrorMessage ="El campo {0} no debe esceder {1} caracteres")]
        public string ApellidoMaterno { get; set; }   
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
    }
}
