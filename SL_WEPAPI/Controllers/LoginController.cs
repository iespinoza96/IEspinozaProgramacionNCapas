using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;





namespace SL_WEPAPI.Controllers
{

    public class LoginController : ApiController
    {


        [HttpPost]
        [Route("login/authenticate")]
        public IHttpActionResult Authenticate([FromBody]ML.Usuario usuario)
        {
            var password = usuario.Password;
            if (usuario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            ML.Result result = BL.Usuario.GetByIdEF(usuario.UserName);

            usuario = (ML.Usuario)result.Object;

            if (result.Correct)
            {
                if (usuario.Password == password)
                {
                    usuario.Token = TokenGenerator.GenerateTokenJwt(usuario.UserName);

                    return Ok(usuario);
                }
                else
                {
                    result.ErrorMessage = "El password ingresado es incorrecto";
                    //return Unauthorized();
                    return Content(HttpStatusCode.Unauthorized, result);//error tipo 401
                }

            }
            else
            {
                result.ErrorMessage = "El usuario no existe en la base de datos";
                //return Unauthorized();
                return Content(HttpStatusCode.Unauthorized, result);//error tipo 401
            }

        }//termina Authenticate

    }// termina login controller
}
