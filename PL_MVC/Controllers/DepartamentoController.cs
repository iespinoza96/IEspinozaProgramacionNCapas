using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        //
        // GET: /Materia/
        [HttpGet]
        public ActionResult GetAll()
        {
            DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();   
            var result = departamentoClient.GetAll();
            //ML.Result result = BL.Departamento.GetAllEF();

            ML.Departamento departamento = new ML.Departamento();
            if (result.Correct)
            {
                departamento.Departamentos = result.Objects.ToList();
                return View(departamento);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

            //ML.Result resultDepartamento = new ML.Result();
            //resultDepartamento.Objects = new List<Object>();

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:10037/api/");

            //    var responseTask = client.GetAsync("departamento");
            //    responseTask.Wait();

            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {

            //        var readTask = result.Content.ReadAsAsync<ML.Result>();
            //        readTask.Wait();

            //        foreach (var resultItem in readTask.Result.Objects)
            //        {
            //            ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
            //            resultDepartamento.Objects.Add(resultItemList);
            //        }
            //        //return View(resultDepartamento); 
            //    }
            //}

            //return View(resultDepartamento); 

        }// termina getall

        //[HttpGet]
        //public ActionResult Form(int? IdDepartamento) //Add { Id null } //Update {Id > 0 }
        //{

        //    ML.Departamento departamento = new ML.Departamento();

        //    //ServiceReferenceDepartamento.DepartamentoClient clientDepto = new ServiceReferenceDepartamento.DepartamentoClient();
        //    //var resultDepto = clientDepto.GetAllEF();

        //    ML.Result resultDepto = BL.Departamento.GetAllEF();

        //    ML.Result resultArea = BL.Area.GetAllEF();

        //    if (resultArea.Correct && resultDepto.Correct)
        //    {
        //        departamento.Area = new ML.Area();
        //        departamento.Area.Areas = resultArea.Objects;

        //        if (IdDepartamento == null)
        //        {
        //            return View(departamento);
        //        }
        //        else
        //        {
        //        //GetById
          
        //            //ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);
        //            //ServiceReferenceDepartamento.DepartamentoClient client = new ServiceReferenceDepartamento.DepartamentoClient();
        //            //var result = client.GetByIdEF(IdDepartamento.Value);

        //            //if (result.Correct)
        //            //{
        //            //    departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
        //            //    departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
        //            //    //departamento.Area = new ML.Area();
        //            //    departamento.Area.Areas = resultArea.Objects;
        //            //    departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;

        //            //    return View(departamento);

        //            //}
        //            //else
        //            //{
        //            //    ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
        //            //    return PartialView("ValidationModal");
        //            //}
        //            ML.Result result = new ML.Result();

        //            try
        //            {
        //                //string urlAPI = System.Configuration.ConfigurationManager.AppSettings["http://localhost:10037/api/"];

        //                using (var client = new HttpClient())
        //                {
        //                    client.BaseAddress = new Uri("http://localhost:10037/api/");
        //                    var responseTask = client.GetAsync("departamento/" + IdDepartamento);
        //                    responseTask.Wait();

        //                    var resultAPI = responseTask.Result;
        //                    if (resultAPI.IsSuccessStatusCode)
        //                    {

        //                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
        //                        readTask.Wait();

        //                        ML.Departamento resultItemList = new ML.Departamento();

        //                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
        //                        result.Object = resultItemList;
        //                        result.Correct = true;

        //                        if (result.Correct)
        //                        {
        //                            departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
        //                            departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
        //                            //departamento.Area = new ML.Area();
        //                            departamento.Area.Areas = resultArea.Objects;
        //                            departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;

        //                            return View(departamento);

        //                        }
        //                        else
        //                        {
        //                            ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
        //                            return PartialView("ValidationModal");
        //                        }

        //                    }

        //                    else
        //                    {
        //                        result.Correct = false;
        //                        result.ErrorMessage = "No existen registros en la tabla Departamento";
        //                    }
        //                }
        //            }

        //            catch (Exception ex)
        //            {

        //                result.Correct = false;
        //                result.ErrorMessage = ex.Message;
        //            }



        //            return View("Form",result); 


        //        }
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ocurrió un error al obtener la información de semestres" + resultArea.ErrorMessage;
        //        return PartialView("ValidationModal");
        //    }


        //}

        //[HttpPost]
        //public ActionResult Form(ML.Departamento departamento) //Add { Id null } //Update {Id > 0 }
        //{
        //    ML.Result result = new ML.Result();

        //    if (departamento.IdDepartamento == 0)
        //    {
        //        DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
        //        var resultDepto = departamentoClient.Add(departamento);


        //        if (resultDepto.Correct)
        //        {
        //            ViewBag.message = "departamento agregado correctamente";
        //        }
        //    }
        //    else
        //    {
        //        //using (var client = new HttpClient())
        //        //{

        //        //    client.BaseAddress = new Uri("http://localhost:10037/api/");

        //        //    //HTTP PUT 

        //        //    var postTask = client.PutAsJsonAsync<ML.Departamento>("departamento", departamento);

        //        //    postTask.Wait();

        //        //    var result = postTask.Result;

        //        //    if (result.IsSuccessStatusCode)
        //        //    {
        //        //        return RedirectToAction("GetAll");
        //        //    }

        //        //}

        //        return View("GetAll"); 

        //    }

        //    if (!result.Correct)
        //    {
        //        ViewBag.Message = "No se pudo agregar correctamente el departamento " + result.ErrorMessage;
        //    }

        //    return PartialView("ValidationModal");

        //}

        //[HttpGet]
        //public ActionResult Delete(int IdDepartamento)
        //{
        //    //ML.Departamento departamento = new ML.Departamento();
        //    //departamento.IdDepartamento = IdDepartamento;
        //    //ServiceReferenceDepartamento.DepartamentoClient client = new ServiceReferenceDepartamento.DepartamentoClient();
        //    //var result = client.DeleteEF(departamento);
        //    ////ML.Result result = BL.Departamento.DeleteEF(departamento);

        //    //if (result.Correct)
        //    //{
        //    //    return RedirectToAction("GetAll");
        //    //}
        //    //else
        //    //{
        //    //    ViewBag.Message = "Ocurrió un error al eliminar el departamento " + result.ErrorMessage;
        //    //    return PartialView("ValidationModal");
        //    //}

        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri("http://localhost:10037/api/");

        //        //HTTP DELETE
        //        var deleteTask = client.DeleteAsync("departamento/" + IdDepartamento);

        //        deleteTask.Wait();

        //        var result = deleteTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {

        //            //resultListProduct = BL.Departamento.GetAllEF();

        //            return RedirectToAction("GetAll");

        //        }

        //    }

        //    return View("GetAll"); 
        //}

	}
}