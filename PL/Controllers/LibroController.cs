using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result resultLibro = new ML.Result();
            resultLibro.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61306/api/");

                var responseTask = client.GetAsync("Libro/GetAll");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        resultLibro.Objects.Add(resultItemList);
                    }
                }
                libro.Libros = resultLibro.Objects;
            }
            return View(libro);
        }
        public ActionResult LibroGetAllFecha()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result resultLibro = new ML.Result();
            resultLibro.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61306/api/");

                var responseTask = client.GetAsync("Libro/LibroGetAllFecha");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        resultLibro.Objects.Add(resultItemList);
                    }
                }
                libro.Libros = resultLibro.Objects;
            }
            return View(libro);
        }
        [HttpGet]
        public ActionResult Form(int? idLibro)
        {
            ML.Result result = new ML.Result();
            ML.Libro materia = new ML.Libro();


            if (idLibro == null)
            {

                return View(materia);
            }

            else
            {

                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://localhost:61306/api/");

                //    var responseTask = client.GetAsync("Materia/GetById/" + idLibro);
                //    responseTask.Wait();
                //    var resultAPI = responseTask.Result;
                //    if (resultAPI.IsSuccessStatusCode)
                //    {
                //        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                //        readTask.Wait();
                //        ML.Materia resultItemList = new ML.Materia();
                //        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                //        materia = resultItemList;


                //    }

                }
                return View(materia);
                if (materia != null)
                {
                    return View();

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta del alumno ";
                    return View("Modal");
                }




                if (result.Correct)
                {


                    ML.Libro ase = (ML.Libro)result.Object;
                    ase.Libro.Libros = resultLibros.Objects;
                    return View(ase);

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta de la aseguradora " + result.ErrorMessage;
                    return View("Modal");
                }


            }

        }

        [HttpPost]
        public ActionResult Form(ML.Libro Libro)
        {

            ML.Result result = new ML.Result();
            if (Libro.IdLibro == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:61306/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Libro>("Materia/Add", Libro);
                    postTask.Wait();

                    var resulLibro = postTask.Result;

                    if (resulLibro.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se ha insertado la aseguradora";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "No ha insertado la aseguradora";
                        return PartialView("Modal");
                    }
                }
                return View("GetAll");
                //result = BL.Aseguradora.Add(aseguradora);
                //if (result.Correct)
                //{
                //    ViewBag.Mensaje = "Se ha insertado la aseguradora";
                //}
                //else
                //{
                //    ViewBag.Mensaje = "Ne ha insertado la aseguradora" + result.ErrorMessage;
                //}
            }
            else
            {
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri("http://localhost:61306/api/");

                //    //HTTP POST
                //    var postTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update/" + Libro.IdMateria, Libro);
                //    postTask.Wait();

                //    var resultAlumno = postTask.Result;
                //    if (resultAlumno.IsSuccessStatusCode)
                //    {
                //        ViewBag.Mensaje = "Se ha actualizado el Aseguradora";
                //        return PartialView("Modal");
                //    }
                //}
                return PartialView("Modal");
            }

            return View();
        }
    //[HttpPost]//servicio web
    public ActionResult Delete(ML.Libro libro)
    {
        ML.Result resultLibro = new ML.Result();
        int IdLibro = libro.IdLibro;
        //int id = Aseguradora.IdAseguradora;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://localhost:61306/api");

            //HTTP POST
            var postTask = client.GetAsync("Materia/Delete/" + IdLibro);
            postTask.Wait();

            var resultDelete = postTask.Result;
            if (resultDelete.IsSuccessStatusCode)
            {
                ViewBag.Message = "Se Borro correctamente el Aseguradora";

                //ML.Aseguradora Aseguradora = new ML.Producto();

                //resultListAseguradora= BL.Aseguradora.GetAll(Aseguradora);
                //return RedirectToAction("Modal");
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "Nose Se Borro correctamente el Aseguradora";

            }
        }

        
    }

}

    

