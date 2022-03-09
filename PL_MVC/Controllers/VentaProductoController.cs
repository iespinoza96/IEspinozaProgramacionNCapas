using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaProductoController : Controller
    {
        //
        // GET: /VentaProducto/
        public ActionResult Index()
        {
            return View("Detalle");
        }

        public ActionResult GetById(int IdVenta)
        {
            ML.Result result = BL.VentaProducto.VentaProductoGetByIdVenta(IdVenta);
            ML.VentaProducto ventaProducto = new ML.VentaProducto();//instancia del modelo

            if (result.Correct)
            {
                ventaProducto.VentaProductos = result.Objects;
            }

            else
            {
                ViewBag.Message = "Ocurrio un error al traer la informacion" + result.ErrorMessage;
            }

            return View("Detalle", ventaProducto);
            
            
        }
	}
}