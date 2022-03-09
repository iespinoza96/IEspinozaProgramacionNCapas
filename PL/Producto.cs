 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
      public static void Add()
        {
            // ingresar los datos del producto 
            ML.Producto producto = new ML.Producto();//instancia 

            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el proveedor del producto");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el departamento del producto");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion del producto");
            producto.Descripcion = Console.ReadLine();
      
            //ML.Result result = BL.Producto.Add(producto); //query
            //ML.Result result = BL.Producto.AddSP(producto); //Stored Procedure
            //ML.Result result = BL.Producto.AddEF(producto); //EntityFramework
            //ML.Result result = BL.Producto.AddLINQ(producto); //LINQ

            ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
            var result = client.AddEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto ingresado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Producto " + result.ErrorMessage);
            }
        }//agregar productos 
      public static void Update()
        {
            // actualizar los datos del producto 
            ML.Producto producto = new ML.Producto();//instancia 

            Console.WriteLine("Ingresa el Id del producto");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio del producto");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock del producto");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el proveedor del producto");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el departamento del producto");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion del producto");
            producto.Descripcion = Console.ReadLine();

            //ML.Result result = BL.Producto.Update(producto);
            //ML.Result result = BL.Producto.UpdateSP(producto);
            //ML.Result result = BL.Producto.UpdateEF(producto);
            //ML.Result result = BL.Producto.UpdateLINQ(producto);

            ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
            var result = client.UpdateEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto Actualizado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla Producto " + result.ErrorMessage);
            }
        }//actualizar productos 
      public static void Delete()
        {
            ML.Producto producto = new ML.Producto();//instancia 

            Console.WriteLine("Ingresa el Id del producto");
            producto.IdProducto =int.Parse (Console.ReadLine());

            //ML.Result result = BL.Producto.Delete(producto);
            //ML.Result result = BL.Producto.DeleteSP(producto);
            //ML.Result result = BL.Producto.DeleteEF(producto);
            //ML.Result result = BL.Producto.DeleteLINQ(producto);
            ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
            var result = client.DeleteEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto borrado correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al borrar el registro en la tabla Producto " + result.ErrorMessage);
            }
        }//borrar productos 
      public static void GetAll()
      {
          
          ML.Result result = BL.Producto.GetAll();
          //ML.Result result = BL.Producto.GetAllEF();
          //ML.Result result = BL.Producto.GetAllLINQ();

          
          //ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
          //var result = client.GetAllEF();
          
          if (result.Correct)
          {
              foreach (ML.Producto producto in result.Objects)
              {
                  Console.WriteLine("IdProducto: " + producto.IdProducto);
                  Console.WriteLine("Nombre: " + producto.Nombre);
                  Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                  Console.WriteLine("Stock: " + producto.Stock);
                  Console.WriteLine("IdProveedor: " + producto.Proveedor);
                  Console.WriteLine("IdDepartamento: " + producto.Departamento);
                  Console.WriteLine("Descripcion: " + producto.Descripcion);
                  Console.WriteLine("Imagen: " + producto.Imagen);
                  Console.WriteLine("*******************************************");
              }
          }
          else
          {
              Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
          }
      }//obtener productos 
      public static void GetById()
      {
          ML.Producto producto = new ML.Producto();

          Console.WriteLine("ingrese el id del producto");
          producto.IdProducto = int.Parse(Console.ReadLine());

          //ML.Result result = BL.Producto.GetByIdSP(IdProducto);
          //ML.Result result = BL.Producto.GetByIdEF(IdProducto);
          //ML.Result result = BL.Producto.GetByIdLINQ(IdProducto);

          ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
          var result = client.GetByIdEF(producto.IdProducto);


          if (result.Correct)
          {
              //ML.Producto producto in result.Object();
              //foreach (ML.Producto producto in result.Objects)
              //{
              producto = ((ML.Producto)result.Object);

                  Console.WriteLine("IdProducto: " + producto.IdProducto);
                  Console.WriteLine("Nombre: " + producto.Nombre);
                  Console.WriteLine("PrecioUnitario: " + producto.PrecioUnitario);
                  Console.WriteLine("Stock: " + producto.Stock);
                  Console.WriteLine("IdProveedor: " + producto.Proveedor);
                  Console.WriteLine("IdDepartamento: " + producto.Departamento);
                  Console.WriteLine("Descripcion: " + producto.Descripcion);
             //}
          }
          else
          {
              Console.WriteLine("Ocurrió un error al consultar la información" + result.ErrorMessage);
          }

      }//selecccionar un producto

     }
}

