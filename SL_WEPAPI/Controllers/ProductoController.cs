using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WEPAPI.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/producto
        [Route("api/producto")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Producto.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/producto/{IdProducto}")] // enviar parametros ->IdDepartamento
        [HttpGet]

        // Get api/departamento
        public IHttpActionResult GetById(int IdProducto)
        {
            ML.Result result = BL.Producto.GetByIdEF(IdProducto);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/producto")]//enviar parametros desde el body 
        [HttpPost]

        // POST api/departamento
        public IHttpActionResult Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.AddEF(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        //PUT 
        [Route("api/producto")]//enviar parametros desde el body 
        [HttpPut]
        public IHttpActionResult Update(ML.Producto producto)
        {
            ML.Result result = BL.Producto.UpdateEF(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/producto")]//enviar parametros desde el body 
        [HttpDelete]
        public IHttpActionResult Delete(ML.Producto producto)
        {
            ML.Result result = BL.Producto.DeleteEF(producto);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

    }
}
