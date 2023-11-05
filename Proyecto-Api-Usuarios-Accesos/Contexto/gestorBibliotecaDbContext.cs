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

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Accesos> Accesos { get; set; }

    }
}
