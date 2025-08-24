using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }
        public string UsuarioLogin { get; set; }

        public string Contraseña { get; set; }

        public int IdSucursal { get; set; }
        public int IdRol {  get; set; }

        public ML.Rol Rol { get; set; }

        public List<object> Usuarios { get; set; }
    }
}
