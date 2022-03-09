using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Rol
    {
        [Display(Name = "Rol:")]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public List<object> Roles { get; set; }
    }
}
