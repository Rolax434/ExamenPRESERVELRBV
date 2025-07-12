using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/tienda")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult TiendaGetAll()
        {
            ML.Result result = BL.Tienda.GetAll();

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
        public IActionResult TiendaGetByID(int idTienda)
        {
            ML.Result result = BL.Tienda.GetByID(idTienda);

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
        public IActionResult TiendaAdd([FromBody] ML.Tienda tienda)
        {
            ML.Result result = BL.Tienda.Add(tienda);

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
        [Route("RelacionarArticulo")]
        public IActionResult TiendaRelacionarArt(int idTienda, int idArticulo)
        {
            ML.Result result = BL.Tienda.AddArticulo(idTienda, idArticulo);

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
        public IActionResult TiendaUpdate([FromBody] ML.Tienda tienda)
        {
            ML.Result result = BL.Tienda.Update(tienda);

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
        public IActionResult TiendaDelete(int idTienda)
        {
            ML.Result result = BL.Tienda.Delete(idTienda);

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
        [Route("GetArtRelacionados")]
        public IActionResult TiendaGetArtRel(int IdTienda)
        {
            ML.Result result = BL.Tienda.GetArticulosRelacionados(IdTienda);

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
        [Route("GetArtDisponibles")]
        public IActionResult TiendaGetArtDis(int IdTienda)
        {
            ML.Result result = BL.Tienda.GetArticulosDisponibles(IdTienda);

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
