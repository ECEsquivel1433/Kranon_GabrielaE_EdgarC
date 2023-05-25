using Microsoft.AspNetCore.Mvc;

namespace SL_API.Controllers
{
    public class LibroController : Controller
    {
        
        [HttpGet]
        [Route("api/Libro/GetAll")]
        public IActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Editorial = new ML.Editorial();
            libro.Autor = new ML.Autor();
            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/Libro/GetAllConsulta")]
        public IActionResult GetAllConsulta([FromBody] ML.Libro libro)
        {
            
            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/Libro/LibroGetAllFecha")]
        public IActionResult LibroGetAllFechal([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.LibroGetAllFecha(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Libro/Add")]
        public IActionResult Add([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Libro/DeleteByAutor")]
        public IActionResult DeleteAutor([FromBody] int IdAutor)
        {

            ML.Result result = BL.Libro.DeleteByAutor(IdAutor);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Libro/DeleteByEditorial")]
        public IActionResult DeleteByEditorial([FromBody] int IdEditorial)
        {

            ML.Result result = BL.Libro.DeleteByEditorial(IdEditorial);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Libro/Delete")]
        public IActionResult Delete([FromBody] int Idlibro)
        {

            ML.Result result = BL.Libro.Delete(Idlibro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

    }
}
