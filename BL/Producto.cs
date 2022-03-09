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
    public class Producto
    {

      //QUERYS

      public static ML.Result Add(ML.Producto producto) // conexion para insertar productos en la BD
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Producto]([Nombre],[PrecioUnitario],[Stock],[IdProveedor],[IdDepartamento],[Descripcion] )VALUES (@Nombre, @PrecioUnitario, @Stock,@IdProveedor, @IdDepartamento, @Descripcion)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;

                        collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
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

      public static ML.Result Update(ML.Producto producto) // conexion para actualizar productos en la BD
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UPDATE Producto SET Nombre=@Nombre, PrecioUnitario=@PrecioUnitario, Stock=@Stock, IdProveedor=@IdProveedor, IdDepartamento=@IdDepartamento, Descripcion=@Descripcion WHERE IdProducto=@IdProducto";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = producto.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                        collection[2].Value = producto.PrecioUnitario;

                        collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                        collection[3].Value = producto.Stock;

                        collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                        collection[4].Value = producto.Proveedor.IdProveedor;

                        collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[5].Value = producto.Departamento.IdDepartamento;

                        collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[6].Value = producto.Descripcion;

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
                            result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Producto";
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

      public static ML.Result Delete(ML.Producto producto) // conexion para borrar productos en la BD
        {
            ML.Result result = new ML.Result();
            try{
                 using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                 { 
                  string query = "DELETE FROM Producto WHERE IdProducto=@IdProducto";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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
                            result.ErrorMessage = "Ocurrió un error al borrar el registro en la tabla Producto";
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

      //STORED PROCEDURE

      public static ML.Result GetAll() //seleccionar datos 
       {
           ML.Result result = new ML.Result();
           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                 string query = "ProductoGetAll";
                 using (SqlCommand cmd = new SqlCommand())
                 {
                     cmd.Connection = context;
                     cmd.CommandText = query;
                     cmd.CommandType = CommandType.StoredProcedure;

                     DataTable tableProducto = new DataTable();

                     SqlDataAdapter da = new SqlDataAdapter(cmd); 

                     da.Fill(tableProducto);

                     if (tableProducto.Rows.Count > 0)
                     {
                         result.Objects = new List<object>();

                         foreach (DataRow row in tableProducto.Rows)
                         {
                             ML.Producto producto = new ML.Producto();
                             producto.IdProducto = int.Parse(row[0].ToString());
                             producto.Nombre = row[1].ToString();
                             producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                             producto.Stock = int.Parse(row[3].ToString());
                             producto.Proveedor = new ML.Proveedor();
                             producto.Proveedor.IdProveedor  = int.Parse(row[4].ToString());
                             producto.Departamento = new ML.Departamento();
                             producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                             producto.Descripcion = row[6].ToString();
                             result.Objects.Add(producto);
                         }

                         result.Correct = true;
                     }
                     else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
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

      public static ML.Result GetByIdSP(int IdProducto) 
       {
           ML.Result result = new ML.Result();
           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   string query = "ProductoGetById";
                   using (SqlCommand cmd = new SqlCommand())
                   {
                       cmd.Connection = context;
                       cmd.CommandText = query;
                       cmd.CommandType = CommandType.StoredProcedure;

                       SqlParameter[] collection = new SqlParameter[1];

                       collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                       collection[0].Value = IdProducto;

                       cmd.Parameters.AddRange(collection);

                       DataTable tableProducto = new DataTable();

                       SqlDataAdapter da = new SqlDataAdapter(cmd);

                       da.Fill(tableProducto);

                       if (tableProducto.Rows.Count > 0)
                       {
                           DataRow  row = tableProducto.Rows[0];
                           
                               ML.Producto producto = new ML.Producto();
                               producto.IdProducto = int.Parse(row[0].ToString());
                               producto.Nombre = row[1].ToString();
                               producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                               producto.Stock = int.Parse(row[3].ToString());
                               producto.Proveedor = new ML.Proveedor();
                               producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());
                               producto.Departamento = new ML.Departamento();
                               producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());
                               producto.Descripcion = row[6].ToString();

                               result.Object = producto; //Boxing  --n variable -> object

                               result.Correct = true;
                        }

                       else
                       {
                           result.Correct = false;
                           result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
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
       }//seleccionar un producto 

      public static ML.Result AddSP(ML.Producto producto)//Stored Procedure agregar datos 
       {
           ML.Result result = new ML.Result();
           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   string query = "ProductoAdd";
                   using (SqlCommand cmd = new SqlCommand())
                   {
                       cmd.Connection = context;
                       cmd.CommandText = query;
                       cmd.CommandType = CommandType.StoredProcedure;

                       SqlParameter[] collection = new SqlParameter[6];

                       collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                       collection[0].Value = producto.Nombre;

                       collection[1] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                       collection[1].Value = producto.PrecioUnitario;

                       collection[2] = new SqlParameter("Stock", SqlDbType.Int);
                       collection[2].Value = producto.Stock;

                       collection[3] = new SqlParameter("IdProveedor", SqlDbType.Int);
                       collection[3].Value = producto.Proveedor.IdProveedor;

                       collection[4] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                       collection[4].Value = producto.Departamento.IdDepartamento;

                       collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                       collection[5].Value = producto.Descripcion;

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
                           result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
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

      public static ML.Result UpdateSP(ML.Producto producto)
       {
           ML.Result result = new ML.Result();
           try
           {
               using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
               {
                   string query = "ProductoUpdate";
                   using (SqlCommand cmd = new SqlCommand())
                   {
                       cmd.Connection = context;
                       cmd.CommandText = query;
                       cmd.CommandType = CommandType.StoredProcedure;

                       SqlParameter[] collection = new SqlParameter[7];

                       collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                       collection[0].Value = producto.IdProducto;

                       collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                       collection[1].Value = producto.Nombre;

                       collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Decimal);
                       collection[2].Value = producto.PrecioUnitario;

                       collection[3] = new SqlParameter("Stock", SqlDbType.Int);
                       collection[3].Value = producto.Stock;

                       collection[4] = new SqlParameter("IdProveedor", SqlDbType.Int);
                       collection[4].Value = producto.Proveedor.IdProveedor;

                       collection[5] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                       collection[5].Value = producto.Departamento.IdDepartamento;

                       collection[6] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                       collection[6].Value = producto.Descripcion;

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
                           result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Producto";
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
       }//Stored Procedure Actualizar datos

      public static ML.Result DeleteSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ProductoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = producto.IdProducto;

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
                            result.ErrorMessage = "Ocurrió un error al borrar el registro en la tabla Producto";
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
        }//stored procedure borrar datos 

      //ENTITY FRAMEWORK

      public static ML.Result AddEF(ML.Producto producto)//Stored Procedure agregar datos Entity framework
      {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var resultQuery = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock,producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
			

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

      public static Result UpdateEF(ML.Producto producto)//stored procedure actualizar datos con Entety Framework
      {
          Result result = new Result();
          try
          {

              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var updateResult = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
                  if (updateResult >= 1)
                  {
                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se actualizó el status de la credencial";
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

      public static Result DeleteEF(ML.Producto producto)
      {
          Result result = new Result();

          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {

                  var query = context.ProductoDelete(producto.IdProducto);
                  if (query >= 1)
                  {
                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se eliminó el registro";
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
      }//stored procedure borrar registro con EntityFramework

      public static Result GetAllEF()
      {
          Result result = new Result();

          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {

                  var productos = context.ProductoGetAll().ToList();

                  result.Objects = new List<object>();

                  if (productos != null)
                  {
                      foreach (var obj in productos)
                      {
                          ML.Producto producto = new ML.Producto();
                          producto.IdProducto = obj.IdProducto;
                          producto.Nombre = obj.ProductoNombre;
                          producto.PrecioUnitario = obj.PrecioUnitario.Value;
                          producto.Stock = obj.Stock.Value;

                          producto.Proveedor = new ML.Proveedor();
                          producto.Proveedor.IdProveedor = obj.IdProveedor.Value;
                          producto.Proveedor.Nombre = obj.ProveedorNombre;

                          producto.Departamento = new ML.Departamento();
                          producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                          producto.Departamento.Nombre = obj.DepartamentoNombre;
                          producto.Descripcion = obj.Descripcion;

                          producto.Departamento.Area = new ML.Area();
                          producto.Departamento.Area.IdArea = obj.IdArea.Value;
                          producto.Departamento.Area.Nombre = obj.AreaNombre;

                          producto.Imagen = obj.Imagen;
                          result.Objects.Add(producto);
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

      public static Result GetByIdEF(int IdProducto)
      {
          ML.Result result = new ML.Result();
          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var objProducto = context.ProductoGetById(IdProducto).FirstOrDefault();

                  result.Objects = new List<object>();

                  if (objProducto != null)
                  {
                      ML.Producto producto = new ML.Producto();

                      producto.IdProducto = objProducto.IdProducto;
                      producto.Nombre = objProducto.ProductoNombre;
                      producto.PrecioUnitario = objProducto.PrecioUnitario.Value;
                      producto.Stock = objProducto.Stock.Value;
                      producto.Proveedor = new ML.Proveedor();
                      producto.Proveedor.IdProveedor = objProducto.IdProveedor.Value;
                      producto.Departamento = new ML.Departamento();
                      producto.Departamento.IdDepartamento = objProducto.IdDepartamento.Value;
                      producto.Descripcion = objProducto.Descripcion;
                      producto.Departamento.Area = new ML.Area();
                      producto.Departamento.Area.IdArea = objProducto.IdArea.Value;
                      producto.Departamento.Area.Nombre = objProducto.AreaNombre;
                      producto.Imagen = objProducto.Imagen;

                      result.Object = producto;

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
      }

      public static Result ProductoGetByIdDepartamento(int IdDepartamento)
      {
          ML.Result result = new ML.Result();
          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var query = context.ProductoGetByIdDepartamento(IdDepartamento);
                  result.Objects = new List<object>();

                  if (query != null)
                  {

                      foreach (var obj in query)
                      {

                          ML.Producto producto = new ML.Producto();

                          producto.IdProducto = obj.IdProducto;
                          producto.Nombre = obj.Nombre;
                          producto.PrecioUnitario = obj.PrecioUnitario.Value;
                          producto.Departamento = new ML.Departamento();
                          producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                          producto.Imagen = obj.Imagen;

                          result.Objects.Add(producto);

                      }

                      result.Correct = true;

                  }

                  else
                  {

                      result.Correct = false;
                      result.ErrorMessage = "No existen registros en la tabla Departamento";

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

      // LINQ 

      public static Result GetAllLINQ()
      {
          Result result = new Result();

          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var query = (from produc in context.Productoes select produc).ToList();

                  result.Objects = new List<object>();

                  if (query != null && query.ToList().Count > 0)
                  {
                      foreach (var obj in query)
                      {
                          ML.Producto pd = new ML.Producto();
                          pd.IdProducto = obj.IdProducto;
                          pd.Nombre = obj.Nombre;
                          pd.PrecioUnitario = obj.PrecioUnitario.Value;
                          pd.Stock = obj.Stock.Value;
                          pd.Proveedor = new ML.Proveedor();
                          pd.Proveedor.IdProveedor = obj.IdProveedor.Value;
                          pd.Departamento = new ML.Departamento();
                          pd.Departamento.IdDepartamento = obj.IdDepartamento.Value;
                          pd.Descripcion = obj.Descripcion;

                          result.Objects.Add(pd);
                      }
                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se encontraron registros";
                  }
              }
          }
          catch (Exception ex)
          {
              result.Correct = false;
              result.ErrorMessage = ex.Message;
          }
          return result;
      }//termina getall con LINQ

      public static Result AddLINQ(ML.Producto producto)
      {
          Result result = new Result();

          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  DL_EF.Producto productoDL = new DL_EF.Producto();

                  //productoDL.IdProducto = producto.IdProducto;
                  productoDL.Nombre = producto.Nombre;
                  productoDL.PrecioUnitario = producto.PrecioUnitario;
                  productoDL.Stock = producto.Stock;
                  productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                  productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                  productoDL.Descripcion = producto.Descripcion;

                  context.Productoes.Add(productoDL);
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
      }//termina addLINQ 

      public static Result UpdateLINQ(ML.Producto producto)
      {
          Result result = new Result();
          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var query = (from p  in context.Productoes
                                   where p.IdProducto == producto.IdProducto
                                   select p).SingleOrDefault();

                  if(query != null)
                  {
                      query.Nombre = producto.Nombre;
                      query.PrecioUnitario = producto.PrecioUnitario;
                      query.Stock = producto.Stock;
                      query.IdProveedor= producto.Proveedor.IdProveedor;
                      query.IdDepartamento= producto.Departamento.IdDepartamento;
                      query.Descripcion = producto.Descripcion;
                      context.SaveChanges();

                      result.Correct = true;
                  }
                  else 
                  {
                      result.Correct = false;
                      result.ErrorMessage ="No se encontro el producto" + producto.IdProducto;
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
      }// TERMINA UPDATELINQ

      public static Result DeleteLINQ(ML.Producto producto)
      {
          Result result = new Result();
          try
          {
              using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
              {
                  var query = (from p in context.Productoes
                               where p.IdProducto == producto.IdProducto
                               select p).First();

                  context.Productoes.Remove(query);
                  context.SaveChanges();

                  if (query != null)
                  {
                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se encontro el producto" + producto.IdProducto;
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
   
      }//TEMINA DELETE LINQ


    }

}
