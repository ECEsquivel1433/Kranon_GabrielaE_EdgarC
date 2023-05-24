﻿using Microsoft.AspNetCore.Mvc;

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
