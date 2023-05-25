using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        private IConfiguration configuration;
        public LibroController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        [HttpGet]
        public ActionResult GetAll()
        {


            ML.Libro libro = new ML.Libro();
            libro.Libros = new List<object>();
            libro.Autor = new ML.Autor();
            libro.Editorial= new ML.Editorial();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebApi"]);

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
                        libro.Libros.Add(resultItemList);
                    }
                }
            }
            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();

            libro.Editorial.Editoriales = resultEditoriales.Objects;
            libro.Autor.Autores = resultAutores.Objects;

            return View(libro);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Libro libro)
        {
            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultar los libros";
            }
            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();

            libro.Editorial.Editoriales = resultEditoriales.Objects;
            libro.Autor.Autores = resultAutores.Objects;
            return View(libro);
        }


        [HttpGet]
        public ActionResult Form(int? idLibro)
        {
            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();

            ML.Libro libro = new ML.Libro();
            libro.Editorial = new ML.Editorial();
            libro.Autor = new ML.Autor();


            libro.Editorial.Editoriales = resultEditoriales.Objects;
            libro.Autor.Autores = resultAutores.Objects;

            //add
            if (idLibro == null)
            {
                return View(libro);
            }
            else //BetById para Update
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebApi"]);

                    var postTask = client.PostAsJsonAsync<int>("Libro/GetById", idLibro.Value);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Libro>();
                        readTask.Wait();
                        libro = readTask.Result;
                    }
                }


                //libro = (ML.Libro)result.Object;
                //ML.Result resultDepartamentos = BL.Departamento.GetByIdArea(libro.Area.IdArea);


                //libro.Departamento.Departamentos = resultDepartamentos.Objects;
                //libro.Proveedor.Proveedores = resultProveedores.Objects;
                //libro.Area.Areas = resultAreas.Objects;

                return View(libro);
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {

            IFormFile file = Request.Form.Files["inpImagen"];

            if (file != null)
            {
                libro.Imagen = Convert.ToBase64String(ConvertToBytes(file));

            }

            ML.Result result = new ML.Result();
            if (libro.IdLibro == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Libro>("Libro/Add", libro);
                    postTask.Wait();

                    var libroresult = postTask.Result;
                    if (libroresult.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se agrego correctamente el libro";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al agregar el libro";
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebApi"]);

                    //HTTP POST
                    var putTask = client.PutAsJsonAsync<ML.Libro>("Libro/Update", libro);
                    putTask.Wait();

                    var libroresult = putTask.Result;
                    if (libroresult.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se actualizo correctamente el libro";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al actualizar el libro";
                    }
                }
                return PartialView("Modal");
            }

            //return PartialView("Modal");
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        public ActionResult LibroDescripcion(int IdLibro)
        {
            ML.Libro libro =new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            ML.Result result = BL.Libro.GetById(IdLibro);

            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al consultar los libros";
            }
            ML.Result resultEditoriales = BL.Editorial.GetAll();
            ML.Result resultAutores = BL.Autor.GetAll();
            libro = (ML.Libro)result.Object;
            libro.Editorial.Editoriales = resultEditoriales.Objects;
            libro.Autor.Autores = resultAutores.Objects;
            return View(libro);
        }

        public ActionResult DeleteByAutor(int IdAutor)
        {

            //int id = Aseguradora.IdAseguradora;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebApi"]);

                //HTTP POST
                var postTask = client.GetAsync("Libro/DeleteByAutor/" + IdAutor);
                postTask.Wait();

                var resultDelete = postTask.Result;
                if (resultDelete.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se Borro correctamente el Libro";


                }
                else
                {
                    ViewBag.Message = "Nose Se Borro correctamente el Libro";

                }
            }


            return View("Modal");
        }

        public ActionResult DeleteByEditorial(int IdEditorial)
        {

            //int id = Aseguradora.IdAseguradora;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebApi"]);

                //HTTP POST
                var postTask = client.GetAsync("Libro/DeleteByEditorial/" + IdEditorial);
                postTask.Wait();

                var resultDelete = postTask.Result;
                if (resultDelete.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se Borro correctamente el Libro";


                }
                else
                {
                    ViewBag.Message = "Nose Se Borro correctamente el Libro";

                }
            }
            return View("Modal");
        }
        public ActionResult Delete(int Idlibro)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebApi"]);

                //HTTP POST
                var postTask = client.PostAsJsonAsync<int>("Libro/Delete", Idlibro);
                postTask.Wait();

                var resultDelete = postTask.Result;
                if (resultDelete.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se Borro correctamente el Libro";


                }
                else
                {
                    ViewBag.Message = "Nose Se Borro correctamente el Libro";

                }
            }


            return View("Modal");
        }

    }
}
    

