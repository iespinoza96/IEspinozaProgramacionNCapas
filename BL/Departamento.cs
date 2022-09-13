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
    public class Departamento
    {
        //STORED PROCEDURE 
        public static ML.Result AddSP(ML.Departamento departamento)//Stored Procedure agregar datos 
        {
            ML.Result result = new ML.Result();
            try  
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

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

        public static ML.Result GetAllSP() //seleccionar datos 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableDepartamento = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDepartamento);

                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());
                                result.Objects.Add(departamento);
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

            finally
            {

            }
            try
            {

            }
            catch (Exception)
            {

                
            }

            return result;
        }

        public static ML.Result GetByIdSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        DataTable tableDepartamento = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDepartamento);

                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();
                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();
                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[4].ToString());
                                result.Objects.Add(departamento);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar el registros en la tabla Departamento";
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
        }//seleccionar un departamento

        public static ML.Result UpdateSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("PrecioUnitario", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;


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
                            result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Departamento";
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

        public static ML.Result DeleteSP(ML.Departamento departamento)
        {
           ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DepartamentoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

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
                            result.ErrorMessage = "Ocurrió un error al borrar el registro en la tabla Departamento";
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

        public static ML.Result AddEF(ML.Departamento departamento)//Stored Procedure agregar datos Entity framework
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var restulQuery = context. DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);


                    if (restulQuery >= 1)
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

        public static Result UpdateEF(ML.Departamento departamento)//stored procedure actualizar datos con Entety Framework
        {
            Result result = new Result();
            try
            {

                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var updateResult = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);
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

        public static Result DeleteEF(int IdDepartamento)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var query = context.DepartamentoDelete(IdDepartamento);

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

                    var departamentos = context.DepartamentoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (departamentos != null)
                    {
                        foreach (var obj in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.DepartamentoNombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea.Value;
                            departamento.Area.Nombre = obj.AreaNombre;

                            result.Objects.Add(departamento);
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

        public static Result GetByIdEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var objDepartamento = context.DepartamentoGetById(IdDepartamento).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objDepartamento != null)
                    {
                        ML.Departamento departamento = new ML.Departamento();
                        departamento.IdDepartamento = objDepartamento.IdDepartamento;
                        departamento.Nombre = objDepartamento.Nombre;
                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objDepartamento.IdArea.Value;

                        result.Object = departamento;

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

        public static Result GetByIdEFArea(int IdArea)
        {

            ML.Result result = new ML.Result();

            try
            {

                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {

                    var query = context.DepartamentoGetByIdArea(IdArea);

                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {

                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;
                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea.Value;

                            result.Objects.Add(departamento);

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

        //LINQ

        public static Result GetAllLINQ()
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var query = (from dep in context.Departamentoes
                                 select dep).ToList();

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Departamento de = new ML.Departamento();
                            de.IdDepartamento = obj.IdDepartamento;
                            de.Nombre = obj.Nombre;
                            de.Area = new ML.Area();
                            de.Area.IdArea = obj.Area.IdArea;

                            result.Objects.Add(de);
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

        public static Result AddLINQ(ML.Departamento departamento)
        {
            Result result = new Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    //productoDL.IdProducto = producto.IdProducto;
                    departamentoDL.Nombre = departamento.Nombre;
                    departamentoDL.IdArea = departamento.Area.IdArea;


                    context.Departamentoes.Add(departamentoDL);
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

        public static Result UpdateLINQ(ML.Departamento departamento)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var query = (from d in context.Departamentoes
                                 where d.IdDepartamento == departamento.IdDepartamento
                                 select d).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;
                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el producto" + departamento.IdDepartamento;
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

        public static Result DeleteLINQ(ML.Departamento departamento)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasEntities context = new DL_EF.IEspinozaProgramacionNCapasEntities())
                {
                    var query = (from d in context.Departamentoes
                                 where d.IdDepartamento == departamento.IdDepartamento
                                 select d).First();

                    context.Departamentoes.Remove(query);
                    context.SaveChanges();

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el producto" + departamento.IdDepartamento;
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
