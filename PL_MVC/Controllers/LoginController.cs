using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Add()
        {
            return RedirectToAction("Form", "Usuario");
        }


        [HttpGet]
        public ActionResult Login()
        {
            ML.Usuario login = new ML.Usuario();
            return View(login);
        }

        public ActionResult IniciarSesion()
        {
            ML.Usuario login = new ML.Usuario();
            return View();
        }

        [HttpPost]
        public ActionResult Login(ML.Usuario usuario)
        {
             //ML.Result result = BL.Usuario.GetByIdEF(usuario.UserName);
            //ML.Usuario usuarioResult = ((ML.Usuario)result.Object);
            using (var client = new HttpClient())
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapi"];
                client.BaseAddress = new Uri(urlAPI);

                var responseTask = client.PostAsJsonAsync("login/authenticate", usuario);

                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var usuarioResultAPI = result.Content.ReadAsAsync<ML.Usuario>();

                    ML.Usuario usuarioAPI = usuarioResultAPI.Result;
                    //if (result.Correct)
                    // {
                    // if (usuario.Password == usuarioResult.Password)
                    // {
                    if (usuarioAPI.Rol.IdRol == 1)
                    {
                        Session["TipoUsuario"] = "1";
                        return RedirectToAction("Index", "Home");
                    }
                    else if (usuarioAPI.Rol.IdRol == 2)
                    {
                        Session["TipoUsuario"] = "2";
                        return RedirectToAction("Producto", "GetAll");
                    }
                    else //if (usuario.Rol.IdRol == 3)
                    {
                        Session["TipoUsuario"] = "3";
                        return RedirectToAction("Producto", "GetAll");
                    }

                }
                else
                {
                    return RedirectToAction("IniciarSesion");
                }
            }
           
        }


        // GET: Loggin
        public ActionResult Index()
        {
            return View();
        }
    }
}