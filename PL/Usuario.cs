using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\digis\Documents\Isaac Jair Espinoza Ocampo\LayaoutUsuarios.txt");

            // Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
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

                if(!result.Correct)
                {
                    var txt = "usuario" + usuario.Nombre + "Se guardo correctamente";
                }
                else
                {
                    var errorMessage = "Usuario" + usuario.Nombre + "no se guardo coreectamente";
                }
                // Use a tab to indent each line of the file.

            }
        }

        //public static void Add()
        //{

        //    try
        //    {

        //        string textfile = @"C:\Users\digis\Documents\Isaac Jair Espinoza Ocampo\LayaoutUsuarios.txt";

        //        using (StreamReader file = new StreamReader())
        //        {
        //            string linea;

        //            while ((linea = file.ReadLine()) != null)
        //            {
        //                string[] lineas = File.ReadAllLines(textfile);
        //                string line;

        //                List<string> lineasList = lineas.Skip(1).ToList();

        //                string[] datosUsuario = line.Split('|');

        //                ML.Usuario usuario = new ML.Usuario();

        //                usuario.UserName = datosUsuario[0];
        //                usuario.Nombre = datosUsuario[1];
        //                usuario.ApellidoPaterno = datosUsuario[2];
        //                usuario.ApellidoMaterno = datosUsuario[3];
        //                usuario.Email = datosUsuario[4];
        //                usuario.Password = datosUsuario[5];
        //                usuario.FechaNacimiento = DateTime.ParseExact(datosUsuario[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);// conversion de fecha 
        //                usuario.Telefono = datosUsuario[7];
        //                usuario.Sexo = datosUsuario[8];
        //                usuario.Status = true;
        //                usuario.Rol = new ML.Rol();
        //                usuario.Rol.IdRol = 1;

        //                ML.Result result = BL.Usuario.AddEF(usuario);
        //            }//termina while
        //            file.Close();
        //        }//termina usuing 

        //    }//termina try 
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

    }
}
