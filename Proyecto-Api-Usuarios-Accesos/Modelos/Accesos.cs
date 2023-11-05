using System.ComponentModel.DataAnnotations;

namespace Proyecto_Api_Usuarios_Accesos.Modelos
{
    public class Accesos
    {
        [Key]
        public int id_acceso { get; set; }
        public string codigo_acceso { get; set; }
        public string descripcion_acceso { get; set; }
    }
}
