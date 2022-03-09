using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Rol
    {
        public static Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var roles = context.RolGetAll().ToList();

                    result.Objects = new List<object>();

                    if (roles != null)
                    {
                        foreach (var obj in roles)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol= obj.IdRol;
                            rol.Nombre = obj.Nombre;

                            result.Objects.Add(rol);
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
    }
}
