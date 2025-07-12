using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult ArticuloGetAll()
        {
            ML.Result result = BL.Articulo.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ERROR: " + result.ErrorMessage);
            }
        }

        [HttpGet]
        [Route("GetByID")]
        public IActionResult ArticuloGetByID(int idArticulo)
        {
            ML.Result result = BL.Articulo.GetByID(idArticulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ERROR: " + result.ErrorMessage);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult ArticuloAdd([FromBody] ML.Articulos articulo)
        {
            ML.Result result = BL.Articulo.Add(articulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ERROR: " + result.ErrorMessage);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult ArticuloUpdate([FromBody] ML.Articulos articulo)
        {
            ML.Result result = BL.Articulo.Update(articulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ERROR: " + result.ErrorMessage);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult ArticuloDelete(int idArticulo)
        {
            ML.Result result = BL.Articulo.Delete(idArticulo);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("ERROR: " + result.ErrorMessage);
            }
        }
    }
}
