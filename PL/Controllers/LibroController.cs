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
        public ActionResult LibroGetAllFecha()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result1 resultLibro = new ML.Result1();
            resultLibro.Objects = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61306/api/");

                var responseTask = client.GetAsync("Libro/LibroGetAllFecha");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result1>();
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
        public ActionResult GetAll()
        {

            ML.Libro libro = new ML.Libro();

            ML.Libro libroObjects = new ML.Libro();
            libroObjects.Objects = new List<object>();
            try
            {
                using (var client = new HttpClient())
                {
                    string str = System.Configuration.ConfigurationManager.AppSettings["WebApi"];
                    client.BaseAddress = new Uri(str);

                    var responseTask = client.GetAsync("Libro/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Libro>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                            libroObjects.Objects.Add(resultItemList);
                        }
                    }
                    libro.Libros = libroObjects.Objects;
                }

            }
            catch (Exception ex)
            {
                libroObjects.Correct = false;
                libroObjects.ErrorMessage = ex.Message;
                libroObjects.Ex = ex;

            }

            return View(libro);
        }

        [HttpPost]

        public ActionResult GetAll(ML.Libro libro)
        {
            ML.Libro result = BL.Libro.GetAll(libro);

            if (result.Correct)

            {
                libro.Libros = result.Objects;

                return View(libro);
            }
            else
            {
                return View(libro);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            ML.Libro resLibro = BL.Libro.GetAll(libro);


            if (resLibro.Correct)
            {
                libro.Libros = resLibro.Objects;
            }
            if (IdLibro == null)
            {
                return View(libro);
            }
            else
            {
                return View(libro);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["WebApi"]);

                var postTask = client.PostAsJsonAsync<ML.Libro>("Libro/Add", libro);
                postTask.Wait();

                var resLibro = postTask.Result;
                if (resLibro.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha agregado el registro";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No se ha agregado el registro";
                    return PartialView("Modal");
                }
            }
        }

        //[HttpDelete]
        //public ActionResult DeleteByAutor(ML.Libro libro)
        //{
        //    ML.Result1 result = new ML.Result1();
        //    int IdAutor = libro.IdAutor;
        //    //int id = Aseguradora.IdAseguradora;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:61306/api");

        //        //HTTP POST
        //        var postTask = client.GetAsync("Libro/DeleteByAutor/" + IdAutor);
        //        postTask.Wait();

        //        var resultDelete = postTask.Result;
        //        if (resultDelete.IsSuccessStatusCode)
        //        {
        //            ViewBag.Message = "Se Borro correctamente el Aseguradora";


        //            return PartialView("Modal");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Nose Se Borro correctamente el Aseguradora";

        //        }
        //    }
        //    return View("Modal");

        //}
        //[HttpDelete]
        //public ActionResult DeleteByEditorial(ML.Libro libro)
        //{
        //    ML.Result1 result = new ML.Result1();
        //    int IdEditorial = libro.IdEditorial;
        //    //int id = Aseguradora.IdAseguradora;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:61306/api");

        //        //HTTP POST
        //        var postTask = client.GetAsync("Libro/DeleteByEditorial/" + IdEditorial);
        //        postTask.Wait();

        //        var resultDelete = postTask.Result;
        //        if (resultDelete.IsSuccessStatusCode)
        //        {
        //            ViewBag.Message = "Se Borro correctamente el Aseguradora";


        //            return PartialView("Modal");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Nose Se Borro correctamente el Aseguradora";

        //        }
        //    }
        //    return View("Modal");

        //}

    }

}

    

