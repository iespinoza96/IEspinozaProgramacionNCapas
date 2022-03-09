using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//DataTables 
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;
using ML;

namespace BL
{
    public class Venta
    {
        public static ML.Result AddSP(ML.Venta venta, List<object> Objects)//Stored Procedure agregar datos 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "VentaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Direction = ParameterDirection.Output;

                        collection[1] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[1].Value = venta.Usuario.UserName;

                        collection[2] = new SqlParameter("Total", SqlDbType.Decimal);
                        collection[2].Value = venta.Total;

                        collection[3] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        collection[3].Value = venta.MetodoPago.IdMetodoPago;

                        //collection[3] = new SqlParameter("Fecha", SqlDbType.DateTime);
                        //collection[3].Value = venta.Fecha;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        venta.IdVenta = (int)cmd.Parameters["IdVenta"].Value;

                        foreach (ML.VentaProducto ventaProducto in Objects)
                        {
                            ventaProducto.Venta = new ML.Venta();
                            ventaProducto.Venta.IdVenta = venta.IdVenta;

                            BL.VentaProducto.AddSP(ventaProducto);
                        }

                        if (RowsAffected > 0)
                        {

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Venta";
                        }
                    }
                }


            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

        public static ML.Result AddEF(ML.Venta venta, List<object> Objects)//Stored Procedure agregar datos Entity framework
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    ObjectParameter IdVenta = new ObjectParameter("IdVenta",typeof(int));

                    var resultQuery = context.VentaAdd(IdVenta, venta.Usuario.UserName, venta.Total, venta.MetodoPago.IdMetodoPago);

                    venta.IdVenta = (int)IdVenta.Value;

                    foreach (ML.VentaProducto ventaproducto in Objects)
                    {
                        ventaproducto.Venta = new ML.Venta();
                        ventaproducto.Venta.IdVenta = venta.IdVenta;

                        BL.VentaProducto.AddEF(ventaproducto);

                    }


                    if (resultQuery >= 1)
                    {
                        result.Object = venta;
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

        public static ML.Result AddLINQ(ML.Venta venta, List<object> Objects)// LINQ 
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    DL_EF.Venta ventadl = new DL_EF.Venta();

                    ventadl.UserName = venta.Usuario.UserName.ToString();
                    ventadl.Total = venta.Total;
                    ventadl.IdMetodoPago = venta.MetodoPago.IdMetodoPago;

                    context.Ventas.Add(ventadl);
                    int rowsAffected = context.SaveChanges();

                    foreach (ML.VentaProducto ventaProducto in Objects)
                    {
                        ventaProducto.Venta = new ML.Venta();
                        ventaProducto.Venta.IdVenta = venta.IdVenta;

                        BL.VentaProducto.AddLINQ(ventaProducto);
                    }

                    if (rowsAffected >= 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al insertar el registro";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}


      
 
