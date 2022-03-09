using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//DataTables 
using System.Data.SqlClient;
using ML;


namespace BL
{
    public class Area
    {
        public static Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var areas = context.AreaGetAll().ToList();

                    result.Objects = new List<object>();

                    if (areas != null)
                    {
                        foreach (var obj in areas)
                        {
                            ML.Area area = new ML.Area();
                            area.IdArea = obj.IdArea;
                            area.Nombre = obj.Nombre;

                            result.Objects.Add(area);
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
