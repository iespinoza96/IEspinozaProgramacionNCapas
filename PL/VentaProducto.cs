using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class VentaProducto
    {
        public static void Add()
        {
            ML.VentaProducto ventaproducto = new ML.VentaProducto();//instancia 

            Console.WriteLine("Ingresa el IdCliente");
            ventaproducto.Venta = new ML.Venta();
            ventaproducto.Venta.IdVenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el precio del producto");
            ventaproducto.Cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock del producto");
            ventaproducto.Producto = new ML.Producto();
            ventaproducto.Producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.VentaProducto.AddSP(ventaproducto);// STORED PROCEDURE
            //ML.Result result = BL.VentaProducto.AddEF(ventaproducto);// ENTITY FRAMEWORK
            //ML.Result result = BL.VentaProducto.AddLINQ(ventaproducto);// LINQ

            if (result.Correct)
            {
                Console.WriteLine("VentaProdcuto agregada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió un error al insertar el registro en la tabla VentaProducto " + result.ErrorMessage);
            }
        }
    }
}
