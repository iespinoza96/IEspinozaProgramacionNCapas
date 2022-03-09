using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Departamento
    {
        public static void AddEF()//agregar departamentos 
        {
            ML.Departamento departamento = new ML.Departamento();//instancioa de departamento

            Console.WriteLine("Ingresa el nombre del departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el area del departamento");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.AddSP(departamento);//STORED PROCEDURE
            //ML.Result result = BL.Departamento.AddEF(departamento); // ENTITY FRAMEWORK
            //ML.Result result = BL.Departamento.AddLINQ(departamento); // LINQ

            ServiceReference1.DepartamentoClient client = new ServiceReference1.DepartamentoClient();
            var result = client.AddEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Departamento ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla departamento " + result.ErrorMessage);
            }
        }

        public static void UpdateEF()
        {
            ML.Departamento departamento = new ML.Departamento();//instancia 

            Console.WriteLine("Ingresa el Id del departamento");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del departamento");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el area del departamento");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.UpdateSP(departamento);//STORED PROCEDURE
            //ML.Result result = BL.Departamento.UpdateEF(departamento);//ENTITY FRAMEWORK
            //ML.Result result = BL.Departamento.UpdateLINQ(departamento);//LINQ

            ServiceReference1.DepartamentoClient client = new ServiceReference1.DepartamentoClient();
            var result = client.UpdateEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Departamento actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Departamento " + result.ErrorMessage);
            }

        }//actualizar departamento

        public static void DeleteEF()
        {
            ML.Departamento departamento = new ML.Departamento();//instancia 

            Console.WriteLine("Ingresa el Id del departamento");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.DeleteSP(departamento);//STORED PROCEDURE
           //ML.Result result = BL.Departamento.DeleteEF(departamento);//ENTITY FRAMEWORK
            //ML.Result result = BL.Departamento.DeleteLINQ(departamento);//LINQ
           ServiceReference1.DepartamentoClient client = new ServiceReference1.DepartamentoClient();
           var result = client.DeleteEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Departamento borrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al borrar el registro en la tabla departamento " + result.ErrorMessage);
            }
        }//borrar departamento

        public static void GetAllEF()
        {
           // ML.Result result = BL.Departamento.GetAllSP();//STORED PROCEDURE
           // ML.Result result = BL.Departamento.GetAllEF(); // ENTITY FRAMEWORK
            //ML.Result result = BL.Departamento.GetAllLINQ(); //LINQ
            ServiceReference1.DepartamentoClient client = new ServiceReference1.DepartamentoClient();
            var result = client.GetAllEF();

            if (result.Correct)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    Console.WriteLine("IdProducto: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                    Console.WriteLine("***********************************************");

                }
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }//sleccionar departamentos

        public static void GetByIdEF()//seleccionar un departamento
        {
            ML.Departamento departamento = new ML.Departamento();
            Console.WriteLine("Ingrese el Id del Departamento:");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());
            ServiceReference1.DepartamentoClient client = new ServiceReference1.DepartamentoClient();
            var result = client.GetByIdEF(departamento.IdDepartamento);

            if (result.Correct)
            {
                departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                departamento.Area = new ML.Area();
                departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;

                
                
                    Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                    Console.WriteLine("Nombre: " + departamento.Nombre);
                    Console.WriteLine("Area: " + departamento.Area.IdArea);

               
            }
            else
            {
                Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
            }
        }

    }
}
