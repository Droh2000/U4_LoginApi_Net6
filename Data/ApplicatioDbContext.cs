/*
    El Data Base Context:
    Es la configuracion de la variable que va a representar a nusetra tabla en la BD
    Aqui vamos a vincular la clase 'Usuario' con esa variable que va a representar la tabla en la BD
*/
using Microsoft.EntityFrameworkCore;
using LoginApi.Models;

namespace LoginApi.Data
{
    public class ApplicatioDbContext:DbContext
    {
        // Configuracion basica para que funcione (Esto siempre va a ir en un Context)
        public ApplicatioDbContext(DbContextOptions<ApplicatioDbContext> options): base(options){}

        // Creacion de la variable que representa la tabla en la BD
        // El nombre de la variable de ser igual al nombre de la tabla en la BD
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
// DEspues de esto hay que agregar la configuracion de la conexion a la BD en el appsetting.json