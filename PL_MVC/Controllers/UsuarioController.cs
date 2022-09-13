using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }// termina getall

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            //ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;

                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }// termina getall

         [HttpGet]
         public ActionResult Form(string UserName) //Add { Id null } //Update {Id > 0 }
         {
             ML.Usuario usuario = new ML.Usuario();
             ML.Result resultRol = BL.Rol.GetAllEF(); // para llenar el DDl de rol

             if (resultRol.Correct)
             {
                 usuario.Rol = new ML.Rol();
                 usuario.Rol.Roles = resultRol.Objects;

                 if (UserName == null)
                 {
                     usuario.Action = "Add";
                     return View(usuario);
                 }
                 else
                 {
                     //GetById
                     ML.Result result = BL.Usuario.GetByIdEF(UserName);

                     if (result.Correct)
                     {
                         usuario.Action = "Update";

                         usuario.UserName = ((ML.Usuario)result.Object).UserName;
                         usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                         usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                         usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                         usuario.Email = ((ML.Usuario)result.Object).Email;
                         usuario.Password = ((ML.Usuario)result.Object).Password;
                         usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                         usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                         usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                         usuario.Status = ((ML.Usuario)result.Object).Status;

                         usuario.Rol = new ML.Rol();
                         usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;

                         return View(usuario);

                     }

                     else
                     {
                         ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                         return PartialView("ValidationModal");
                     }
                 }
             }
             else
             {
                 ViewBag.Message = "Ocurrio un error al obtener la informacion" + resultRol.ErrorMessage;
                 return PartialView("ValidationModal");
             }
         }

         [HttpPost]
         public ActionResult Form(ML.Usuario usuario) //Add { Id null } //Update {Id > 0 }
         {
             ML.Result result = new ML.Result();

             if (usuario.Action == "Add")
             {              
                 if (usuario.UserName == null)
                 {
                     result = BL.Usuario.AddEF(usuario);

                     if (result.Correct)
                     {
                         ViewBag.Message = "Usuario agregado correctamente";
                     }
                 }
             }

             else
             {
                 result = BL.Usuario.UpdateEF(usuario);
                 if (result.Correct)
                 {
                     ViewBag.Message = "Usuario actualizado correctamente";
                 }
             }

             if (!result.Correct)
             {
                 ViewBag.Message = "No se pudo agregar correctamente el Usuario " + result.ErrorMessage;
             }

             return PartialView("ValidationModal");

         }

         public ActionResult UpdateStatus(string UserName)
         {
             ML.Usuario usuario = new ML.Usuario();
             ML.Result result = BL.Usuario.GetByIdEF(UserName);

             if (result.Correct)
             {
                 usuario = ((ML.Usuario)result.Object);

                 usuario.Status = (usuario.Status) ? false : true; // operador ternario 

                 //if (usuario.Status == true)
                 //{
                 //    usuario.Status = false;
                 //}
                 //else
                 //{
                 //    usuario.Status = true;
                 //}

                 ML.Result resultUpdate = BL.Usuario.UpdateEF(usuario);

                 ViewBag.Message = "Se actualizo el status del usuario";
             }

             else
             {
                 ViewBag.Message = "No se actualizo el status del usuario" + result.ErrorMessage;
             }

             return PartialView("ValidationModal");
         }

        [HttpPost]
         public ActionResult CargaMasiva()
         {
             try
             {
                 HttpPostedFileBase file = Request.Files["Archivo"];
                 // Create an instance of StreamReader to read from a file.
                 // The using statement also closes the StreamReader.
                 using (StreamReader sr = new StreamReader(file.InputStream))
                 {
                     string line;
                     // Read and display lines from the file until the end of
                     // the file is reached.
                     while ((line = sr.ReadLine()) != null)
                     {
                         string[] datosUsuario = line.Split('|');


                         ML.Usuario usuario = new ML.Usuario();

                         usuario.UserName = datosUsuario[0];
                         usuario.Nombre = datosUsuario[1];
                         usuario.ApellidoPaterno = datosUsuario[2];
                         usuario.ApellidoMaterno = datosUsuario[3];
                         usuario.Email = datosUsuario[4];
                         usuario.Password = datosUsuario[5];
                         usuario.FechaNacimiento = DateTime.ParseExact(datosUsuario[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                         usuario.Telefono = datosUsuario[7];
                         usuario.Sexo = datosUsuario[8];
                         usuario.Status = true;
                         usuario.Rol = new ML.Rol();
                         usuario.Rol.IdRol = 1;

                         ML.Result result = BL.Usuario.AddEF(usuario);
                     }
                     
                 }
             }
             catch (Exception e)
             {
                 // Let the user know what went wrong.
                 Console.WriteLine("The file could not be read:");
                 Console.WriteLine(e.Message);
             }

             return PartialView("ValidationModal");
         }




	}
}