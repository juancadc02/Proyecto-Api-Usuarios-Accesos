using Microsoft.EntityFrameworkCore;
using Proyecto_Api_Usuarios_Accesos.Modelos;

namespace Proyecto_Api_Usuarios_Accesos.Contexto
{
    public class gestorBibliotecaDbContext: DbContext
    {










        #region Constructores

        //Cremoa el constructor por defecto y el contructor que recibe el DbContext
        public gestorBibliotecaDbContext(){

        }
        public gestorBibliotecaDbContext(DbContextOptions<gestorBibliotecaDbContext> opcions) : base(opcions){

        }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Proyecto-GestorBiblioteca-LosRapidos;User Id=postgres;Password=1234; SearchPath=public");

        }


        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Accesos> Accesos { get; set; }

    }
}
