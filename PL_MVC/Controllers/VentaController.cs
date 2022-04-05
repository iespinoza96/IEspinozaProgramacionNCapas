using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PL_MVC.Controllers
{
	public class VentaController : Controller
	{
	   // GET: /Venta/

		[HttpPost]
		public ActionResult ProductoGetAll(ML.Producto producto)
		{
			ML.Result result = BL.Producto.ProductoGetByIdDepartamento(producto.Departamento.IdDepartamento);
			ML.Result resultDepartamento = BL.Departamento.GetByIdEFArea(producto.Departamento.Area.IdArea);
			ML.Result resultArea = BL.Area.GetAllEF();

			producto.Departamento.Departamentos = resultDepartamento.Objects;
			producto.Departamento.Area.Areas = resultArea.Objects;
			producto.Productos = result.Objects;

			return View("ProductoGetAll", producto);
		}

		[HttpGet]
		public ActionResult ProductoGetAll()
		{

			ML.Result result = BL.Producto.GetAllEF();
			ML.Producto producto = new ML.Producto();
			ML.Result resultDepartamento = BL.Departamento.GetAllEF();
			ML.Result resultAreas = BL.Area.GetAllEF();

			producto.Departamento = new ML.Departamento();
			producto.Departamento.Area = new ML.Area();
 
			if (result.Correct)
			{
			 
				producto.Departamento.Departamentos = resultDepartamento.Objects;
				producto.Departamento.Area.Areas = resultAreas.Objects;
			  //producto.Productos = result.Objects;
				return View(producto);
			}
			else
			{
				ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
				return PartialView("ValidationModal");
			}

		}// termina getall

		public JsonResult GetDepartamento(int IdArea)
		{
			ML.Departamento depto = new ML.Departamento();

			depto.IdDepartamento = 0;
			depto.Nombre = "Seleccione una opción";

			var result = BL.Departamento.GetByIdEFArea(IdArea);
			result.Objects.Insert(0, depto);

			return Json(result.Objects, JsonRequestBehavior.AllowGet);


		} 

		[HttpGet]
		public ActionResult Carrito(int? IdProducto)//int IdProducto
		{
			ML.Result result = new ML.Result();
			result.Objects = new List<object>();
			if (IdProducto != null)
			{
				if (Session["Carrito"] == null)
				{ //Inicia sesion para agregar producto al carrito 

					ML.VentaProducto ventaProducto = new ML.VentaProducto();

					ventaProducto.Producto = new ML.Producto();
					ventaProducto.Producto.IdProducto = IdProducto.Value;

					ventaProducto.Cantidad = 1;

					ML.Result resultProducto = BL.Producto.GetByIdEF(IdProducto.Value);

					if (resultProducto.Correct)
					{
						ventaProducto.Producto = (ML.Producto)resultProducto.Object;

						//result.Objects = new List<object>();
						result.Objects.Add(ventaProducto);
					}

					Session["Carrito"] = result.Objects;
				}

				else
				{// comprobar si ya existe informacion en el carrito
					result.Objects = (List<Object>)Session["Carrito"];

					bool Existe = false;
					var indice = 0; //variable para el index

					foreach (ML.VentaProducto ventaProducto in result.Objects)
					{// foreach que recorre el objeto venta producto
						if (ventaProducto.Producto.IdProducto == IdProducto)
						{// if que compara el id de el producto con el de ventaproducto

							Existe = true;
							indice = result.Objects.IndexOf(ventaProducto);//index 

						}
					}

					if (Existe == true)
					{
						foreach (ML.VentaProducto ventaProducto in result.Objects)
						{
							ventaProducto.Cantidad = ventaProducto.Cantidad + 1;//contador 
						}

					}

					else
					{

						ML.VentaProducto ventaProducto = new ML.VentaProducto();

						ventaProducto.Producto = new ML.Producto();
						ventaProducto.Producto.IdProducto = IdProducto.Value;
						ventaProducto.Cantidad = 1;


						ML.Result resultProducto = BL.Producto.GetByIdEF(IdProducto.Value);

						if (resultProducto.Correct)
						{
							ventaProducto.Producto = (ML.Producto)resultProducto.Object;

							result.Objects.Add(ventaProducto);

						}

						Session["Carrito"] = result.Objects;

					}

				}
			}

			return View(result);
		}
		
		public ActionResult Sumar(int IdProducto)
		{
			ML.Result result = new ML.Result();

			result.Objects = (List<Object>)Session["Carrito"];//unboxing de la lista

			foreach (ML.VentaProducto ventaProducto in result.Objects) //para comparar
			{
				if(ventaProducto.Producto.IdProducto == IdProducto)
				{

					ventaProducto.Cantidad +=1;//aumenta la cantida
		  
				}
			}
			return View("Carrito", result); 
		} // metodo que le agrega 1 a la cantidad del producto en la lista de venta 

		public ActionResult Restar(int IdProducto)
		{
			ML.Result result = new ML.Result();

			result.Objects = (List<Object>)Session["Carrito"];//unboxing de la lista

			foreach (ML.VentaProducto ventaProducto in result.Objects) //para comparar
			{

				if (ventaProducto.Producto.IdProducto == IdProducto)
				{
					ventaProducto.Cantidad -=1;//aumenta la cantidad
				}
			}
			return View("Carrito", result);
		}//metodo que resta la cantidad de un producto en la lista de venta 

		public ActionResult Eliminar(int IdProducto)
		{
			ML.Result result = new ML.Result();
			result.Objects = (List<Object>)Session["Carrito"];

			var indice = 0; //variable para el index

			foreach (ML.VentaProducto ventaProducto in result.Objects)
			{// foreach que recorre el objeto venta producto
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{// if que compara el id de el producto con el de ventaproducto
					
					indice = result.Objects.IndexOf(ventaProducto);//index 

				}
			}

			result.Objects.RemoveAt(indice);
			Session["Carrito"] = result.Objects;

			return View("Carrito", result);
		}// metodo que elimina un producto de la lista de venta 

		public decimal GetTotal(List<object> Objects)
		{
			decimal Total = 0;

			foreach (ML.VentaProducto ventaProducto in Objects)
			{
				Total += ventaProducto.Producto.PrecioUnitario * ventaProducto.Cantidad;
			}

			return Total;
		} // metodo que devuelve la suma del total de los productos comprados 
		public ActionResult Procesar()
		{
			ML.Result result = new ML.Result();
			result.Objects = (List<Object>)Session["Carrito"];

			ML.Venta venta = new ML.Venta();
		   
			venta.Usuario = new ML.Usuario();
			venta.Usuario.UserName = "Isaac";

			venta.MetodoPago = new ML.MetodoPago();
			venta.MetodoPago.IdMetodoPago = 1;

			venta.Total = GetTotal(result.Objects);

			result= BL.Venta.AddEF(venta, result.Objects);//guardar el resultado de una vartiable en un metodo 

			venta.IdVenta = ((ML.Venta)result.Object).IdVenta;// unboxing 

			return RedirectToAction("GetById", "VentaProducto", new { IdVenta = venta.IdVenta });

		}//metodo que devuelve el detalle de los productos elegidos para comprar 

		public ActionResult ModalCompra()
		{
			ViewBag.Message = "¿Deseas finalizar tu compra?";
			return PartialView("ValidationModal");
		}

 
	}
}