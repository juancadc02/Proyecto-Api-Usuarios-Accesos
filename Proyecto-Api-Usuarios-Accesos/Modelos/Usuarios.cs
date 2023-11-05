using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Api_Usuarios_Accesos.Modelos
{
    public class Usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string dni_usuario { set; get; }
        public string nombre_usuario { set; get; }
        public string apellidos_usuario { set; get; }
        public string tlf_usuario { set; get; }
        public string email_usuario { get; set; }
        public string clave_usuario { set; get; }

        [ForeignKey("accesos")]
        public int id_acceso { get; set; }
        public bool estaBloqueado_usuario { get; set; }
        public DateTime fch_fin_bloqueo_usuario { get; set; }
        public DateTime fch_alta_usuario { get; set; }
        public DateTime fch_baja_usuario { get; set; }

        //Propiedades de tabla 
        public Accesos accesos { get; set; }
    }
}
