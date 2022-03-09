using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WEPAPI.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET api/departamento
        [Route("api/departamento")]
        [HttpGet]   
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route ("api/departamento/{IdDepartamento}")] // enviar parametros ->IdDepartamento
        [HttpGet]

        // Get api/departamento
        public IHttpActionResult GetById(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route ("api/departamento")]//enviar parametros desde el body 
        [HttpPost]
    
        // POST api/departamento
        public IHttpActionResult Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);

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
        [Route("api/departamento")]//enviar parametros desde el body 
        [HttpPut]
        public IHttpActionResult Update(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateEF(departamento);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [Route("api/departamento/{IdDepartamento}")]//enviar parametros desde el body 
        [HttpDelete]
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF(IdDepartamento);

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
