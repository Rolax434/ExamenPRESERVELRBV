using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult ClienteGetAll()
        {
            ML.Result result = BL.Cliente.GetAll();

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
        public IActionResult ClienteGetByID(int idCliente)
        {
            ML.Result result = BL.Cliente.GetByID(idCliente);

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
        public IActionResult TiendaAdd([FromBody] ML.Cliente cliente)
        {
            ML.Result result = BL.Cliente.Add(cliente);

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
        [Route("Comprar")]
        public IActionResult ClienteComprar([FromBody]ML.Compra compra)
        {
            ML.Result result = BL.Cliente.AddCompra(compra.IdCliente, compra.IdArticulo, compra.Cantidad);

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
        public IActionResult ClienteUpdate([FromBody] ML.Cliente cliente)
        {
            ML.Result result = BL.Cliente.Update(cliente);

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
        public IActionResult ClienteDelete(int idCliente)
        {
            ML.Result result = BL.Cliente.Delete(idCliente);

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
        [Route("GetHistorialCompras")]
        public IActionResult ClienteGetHistorial(int IdCliente)
        {
            ML.Result result = BL.Cliente.GetHistorialCompras(IdCliente);

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
