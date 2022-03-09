using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ML
{
    public class Usuario
    {
        [Display(Name = "Nombre de Usuario:")]
        [Required(ErrorMessage = "UserName es requerido")]
        public string UserName { get; set; }


        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido Paterno:")]
        [Required(ErrorMessage = "ApellidoPaterno es requerido")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno:")]
        [Required(ErrorMessage = "ApellidoMaterno es requerido")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Correo Electrónico:")]
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }

        [Display(Name = "Contraseña:")]
        [Required(ErrorMessage = "Password es requerido")]
        public string Password { get; set; }

        [Display(Name = "Fecha de nacimiento:")]
        [Required(ErrorMessage = "FechaNacimiento es requerido")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Teléfono:")]
        [Required(ErrorMessage = "Telefono es requerido")]
        public string Telefono { get; set; }

        [Display(Name = "Genero:")]
        [Required(ErrorMessage = "Sexo es requerido")]
        public string Sexo { get; set; }

        [Display(Name = "Status:")]
        [Required(ErrorMessage = "Status es requerido")]
        public bool Status { get; set; }

        [Display(Name = "Rol:")]
        [Required(ErrorMessage = "Rol es requerido")]
        public ML.Rol Rol{ get; set;  }

        public List<object> Usuarios { get; set; }

        public string Action { get; set; }

        public string Token { get; set; } 
       
    }
}
