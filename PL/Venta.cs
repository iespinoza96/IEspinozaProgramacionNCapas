using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Venta
    {
        public static void Add()//agregar venta 
        {
            Console.WriteLine("Deseas iniciar una compra? 1.- SI 2.- NO");
            byte opcion = byte.Parse(Console.ReadLine());

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            ML.Venta venta = new ML.Venta();
            venta.IdVenta = 0;
            while (opcion == 1)
            {
                Console.WriteLine("Productos existentes");
                Console.WriteLine("***************************");
                PL.Producto.GetAll();

                Console.WriteLine("Ingresa el ID del Prodcuto que desas comprar");
                Console.WriteLine("***********************************************");

                ML.VentaProducto ventaProducto = new ML.VentaProducto();

                ventaProducto.Producto = new ML.Producto();//instancia que cambia la forma de comportamiento de un objeto
                ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la cantidad del producto que deseas comprar");
                Console.WriteLine("*******************************************************");

                ventaProducto.Cantidad = int.Parse(Console.ReadLine());

                ML.Result resultProducto = BL.Producto.GetByIdSP(ventaProducto.Producto.IdProducto);

                if (resultProducto.Correct)
                {
                    //unboxing
                    venta.Total += ((ML.Producto)resultProducto.Object).PrecioUnitario * ventaProducto.Cantidad;
                    //venta.Total = venta.Total + ((ML.Producto)resulProducto.Object).Costo * ventaProducto.Cantidad;
                    result.Objects.Add(ventaProducto);

                    Console.WriteLine("Deseas Continuar con la compra? 1.-SI 2.-NO");
                    Console.WriteLine("***********************************************");
                    opcion = byte.Parse(Console.ReadLine());
                }

                else
                {
                    Console.WriteLine("El Id del producto ingresado no existe");
                }

            }//termina ciclo while 

            Console.WriteLine("Ingresa tu Id de Cliente");
            Console.WriteLine("***************************");
            venta.Usuario = new ML.Usuario();
            venta.Usuario.UserName = Console.ReadLine();

            Console.WriteLine("Esoje tu metodo de pago");
            Console.WriteLine("***************************");
            Console.WriteLine("1.- Tarjeta de credito");
            Console.WriteLine("2.- Tarjeta de debito");
            Console.WriteLine("3.- Transferencia bancaria");
            Console.WriteLine("4.- Efectivo");
            venta.MetodoPago = new ML.MetodoPago();
            venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

            if (opcion == 2)
            {

                //result =  BL.Venta.AddSP(venta,result.Objects);//se agregan los producto a la lista de objetos
                //result = BL.Venta.AddEF(venta, result.Objects);//se agregan los producto a la lista de objetos 
                result = BL.Venta.AddLINQ(venta, result.Objects);//se agregan los producto a la lista de objetos 

                if(result.Correct)
                {
                    Console.WriteLine("Venta insertada");
                }
                else
                {
                    Console.WriteLine("Venta no insertada"+ result.ErrorMessage);
                }

            }
            
            
            Console.ReadKey();
        }
        

    }
}
