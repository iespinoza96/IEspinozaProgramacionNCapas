using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            //ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
            //var result = client.GetAllEF();
            ML.Producto producto = new ML.Producto();


            if (result.Correct)
            {
                producto.Productos = result.Objects.ToList(); 
                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }// termina getall

        [HttpGet]
        public ActionResult Form(int? IdProducto) //Add { Id null } //Update {Id > 0 }
        {
            ML.Producto producto = new ML.Producto();

            ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            ML.Result resultDepartamento = BL.Departamento.GetAllEF();

            //ServiceReferenceDepartamento.DepartamentoClient clientDepto = new ServiceReferenceDepartamento.DepartamentoClient();
            //var resultDepto = clientDepto.GetAllEF();

            ML.Result resultDepto = BL.Departamento.GetAllEF();

            ML.Result resultArea = BL.Area.GetAllEF();

                producto.Proveedor = new ML.Proveedor();
                producto.Proveedor.Proveedores = resultProveedor.Objects;

                producto.Departamento = new ML.Departamento();
                producto.Departamento.Departamentos = resultDepto.Objects.ToList();

                producto.Departamento.Area = new ML.Area();
                producto.Departamento.Area.Areas = resultArea.Objects;

                if (IdProducto == null)
                {
                    return View(producto);
                }
                else
                {
                    //GetById
                    //ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
                    //var result = client.GetByIdEF(IdProducto.Value);
                    ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);


                    if (result.Correct)
                    {
                        producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                        producto.Nombre = ((ML.Producto)result.Object).Nombre;
                        producto.PrecioUnitario = ((ML.Producto)result.Object).PrecioUnitario;
                        producto.Stock = ((ML.Producto)result.Object).Stock;

                        producto.Proveedor.Proveedores = resultProveedor.Objects;
                        producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                        producto.Proveedor.Nombre = ((ML.Producto)result.Object).Proveedor.Nombre;

                        producto.Departamento.Area.Areas = resultArea.Objects;
                        producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                        producto.Departamento.Area.Nombre = ((ML.Producto)result.Object).Departamento.Area.Nombre;

                        if (producto.Departamento.Area.IdArea > 0)
                        {
                            resultDepartamento = BL.Departamento.GetByIdEFArea(producto.Departamento.Area.IdArea);
                            producto.Departamento.Departamentos = resultDepto.Objects.ToList();
                        }
                        else
                        {
                            producto.Departamento.Departamentos = resultDepto.Objects.ToList();
                        }
                        
                        producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                        producto.Departamento.Nombre = ((ML.Producto)result.Object).Departamento.Nombre;

                        producto.Descripcion = ((ML.Producto)result.Object).Descripcion;

                        producto.Imagen = ((ML.Producto)result.Object).Imagen;
                        

                        return View(producto);

                    }

                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto) //Add { Id null } //Update {Id > 0 }
        {
            //ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];

            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }
        
            if (producto.IdProducto == 0)
            {
                ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
                var result = client.AddEF(producto);
                //result = BL.Producto.AddEF(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "Producto agregado correctamente";
                }
            }
            else
            {
                //result = BL.Producto.UpdateEF(producto);
                ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
                var result = client.UpdateEF(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "Producto actualizado correctamente";
                }
            }

            //if (!result.Correct)
            //{
            //    ViewBag.Message = "No se pudo agregar correctamente el departamento " + result.ErrorMessage;
            //}

            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)//eliminar producto
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;

            ServiceReferenceProducto.ProductoClient client = new ServiceReferenceProducto.ProductoClient();
            var result = client.DeleteEF(producto);
            //ML.Result result = BL.Producto.DeleteEF(producto);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al eliminar el producto " + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }

        public JsonResult GetDepartamento(int IdArea)
        {
            ML.Departamento depto = new ML.Departamento();

            depto.IdDepartamento = 0;
            depto.Nombre = "Seleccione una opción";

            var result = BL.Departamento.GetByIdEFArea(IdArea);
            result.Objects.Insert(0, depto);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);


        } 

	}
}