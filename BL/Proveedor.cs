using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//DataTables 
using System.Data.SqlClient;
using ML;
using System.Data.Entity.Core.Objects;

namespace BL
{
    public class Proveedor
    {
        public static Result GetAllEF()
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var proveedores = context.ProveedorGetAll().ToList();

                    result.Objects = new List<object>();

                    if (proveedores != null)
                    {
                        foreach (var obj in proveedores)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();

                            proveedor.IdProveedor = obj.IdProveedor;
                            proveedor.Nombre = obj.Nombre;
                            proveedor.Telefono = obj.Telefono;

                            result.Objects.Add(proveedor);
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


        public static Result GetByIdEF(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var objProveedor = context.ProveedorGetById(IdProveedor).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objProveedor != null)
                    {
                        ML.Proveedor proveedor = new ML.Proveedor();
                        proveedor.IdProveedor = objProveedor.IdProveedor;
                        proveedor.Nombre = objProveedor.Nombre;
                        proveedor.Telefono = objProveedor.Telefono;

                        result.Object = proveedor;

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
        }//termina getbyid
    }
}
