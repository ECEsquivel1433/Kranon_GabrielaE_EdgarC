using Microsoft.AspNetCore.Mvc;

namespace SL_API.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Libro/GetAll")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAll();

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
        public IActionResult LibroGetAllFechal()
        {
            ML.Result result = BL.Libro.LibroGetAllFecha();

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
        [HttpDelete]
        [Route("api/Libro/DeleteByAutor")]
        public IActionResult DeleteAutor([FromBody] byte libro)
        {

            ML.Result result = BL.Libro.DeleteByAutor(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpDelete]
        [Route("api/Libro/DeleteByEditorial")]
        public IActionResult DeleteByEditorial([FromBody] byte libro)
        {

            ML.Result result = BL.Libro.DeleteByEditorial(libro);

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
