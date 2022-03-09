using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;


namespace BL
{
    public class Usuario
    {
        //ENTITY FRAMEWORK
        public static Result GetAllEF(ML.Usuario usuario)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var usuarios = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno,usuario.ApellidoMaterno).ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            usuario = new ML.Usuario();

                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password = Encoding.ASCII.GetString(obj.Password);
                            usuario.FechaNacimiento = obj.FechaNacimiento;
                            usuario.Telefono = obj.Telefono;
                            usuario.Sexo = obj.Sexo;
                            usuario.Status = obj.Status.Value;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;

                            result.Objects.Add(usuario);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }//termina getallEF

        public static ML.Result AddEF(ML.Usuario usuario)//Stored Procedure agregar datos Entity framework
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var resultQuery = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, Encoding.ASCII.GetBytes(usuario.Password), usuario.FechaNacimiento, usuario.Telefono, usuario.Sexo, usuario.Status, usuario.Rol.IdRol);


                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Result GetByIdEF(string UserName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetById(UserName).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = Encoding.ASCII.GetString(objUsuario.Password);
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Status = objUsuario.Status.Value;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;

                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }// GetById Usuario

        public static Result UpdateEF(ML.Usuario usuario)//stored procedure actualizar datos con Entety Framework
        {
            Result result = new Result();
            try
            {

                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var updateResult = context.UsuarioUpdate(usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, Encoding.ASCII.GetBytes(usuario.Password), usuario.FechaNacimiento, usuario.Telefono, usuario.Sexo, usuario.Status, usuario.Rol.IdRol);
                    if (updateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        //result.ErrorMessage = "No se actualizó el status de la credencial";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
