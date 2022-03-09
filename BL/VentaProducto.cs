using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//DataTables 
using System.Data.SqlClient;//SQL CLIENT
using ML;
using System.Data.Entity.Core.Objects;

namespace BL
{
    public class VentaProducto
    {
        //SP

        public static ML.Result AddSP(ML.VentaProducto ventaproducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "VentaProductoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];


                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Value = ventaproducto.Venta.IdVenta;

                        collection[1] = new SqlParameter("Cantidad", SqlDbType.Decimal);
                        collection[1].Value = ventaproducto.Cantidad;

                        collection[2] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[2].Value = ventaproducto.Producto.IdProducto;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla VentaProducto";
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

        //EF
        public static ML.Result AddEF(ML.VentaProducto ventaproducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var resultQuery = context.VentaProductoAdd(ventaproducto.Venta.IdVenta, ventaproducto.Cantidad, ventaproducto.Producto.IdProducto);


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

        public static Result VentaProductoGetByIdVenta(int IdVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var query = context.VentaProductoGetByIdVenta(IdVenta).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {

                            ML.VentaProducto ventaProducto = new ML.VentaProducto();

                            ventaProducto.IdVentaProducto = obj.IdVentaProducto;
                            ventaProducto.Venta = new ML.Venta();
                            ventaProducto.Venta.IdVenta = obj.IdVenta;
                            ventaProducto.Cantidad = obj.Cantidad;
                            ventaProducto.Producto = new ML.Producto();
                            ventaProducto.Producto.IdProducto = obj.IdProducto;
                            ventaProducto.Producto.Nombre = obj.ProductoNombre;
                            ventaProducto.Producto.PrecioUnitario = obj.ProductoPrecioUnitario.Value;
                            ventaProducto.Producto.Descripcion = obj.ProductoDescripcion;
                            ventaProducto.Producto.Imagen = obj.ProductoImagen;
                            ventaProducto.Venta.Total = obj.VentaTotal;

                            
                            
                            result.Objects.Add(ventaProducto);

                        }
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Venta";
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
        //LINQ
        public static ML.Result AddLINQ(ML.VentaProducto ventaproducto)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    DL_EF.VentaProducto vpDL = new DL_EF.VentaProducto();

                    vpDL.IdVenta = ventaproducto.Venta.IdVenta;
                    vpDL.Cantidad = ventaproducto.Cantidad;
                    vpDL.IdProducto = ventaproducto.Producto.IdProducto;

                    context.VentaProductoes.Add(vpDL);
                    context.SaveChanges();
                    int rowsAffected = context.SaveChanges();

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
