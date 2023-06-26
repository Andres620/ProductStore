using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Implementation;
using ProductStore.Mappers.Core;
using ProductStore.Models.Core;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoApplication _app;

        public PedidoController(IPedidoApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public ActionResult<List<PedidoModel>> GetAllPedidos()
        {
            PedidoAPIMapper mapper = new PedidoAPIMapper();
            IEnumerable<PedidoModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PedidoModel> GetPedidoById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PedidoAPIMapper mapper = new PedidoAPIMapper();
            PedidoModel pedidoModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (pedidoModel == null)
            {
                return NotFound();
            }
            return Ok(pedidoModel);
        }

        [HttpGet("usuario/{id}/pedidos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PedidoModel> GetPedidosByUserId(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            PedidoAPIMapper mapper = new PedidoAPIMapper();
            IEnumerable<PedidoModel> list = mapper.DTOToModelMapper(_app.getRecordsByUserId(id));
            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PedidoModel> CreatePedido(PedidoModel pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }
            PedidoAPIMapper mapper = new PedidoAPIMapper();
            var response = _app.createRecord(mapper.ModelToDTOMapper(pedido));

            if (response == null)
            {
                return Conflict();
            }

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePedido(PedidoModel pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            PedidoAPIMapper mapper = new PedidoAPIMapper();
            PedidoModel pedidoModel = mapper.DTOToModelMapper(_app.getRecordById(pedido.Id));
            if (pedidoModel == null)
            {
                return NotFound();
            }
            _app.updateRecord(mapper.ModelToDTOMapper(pedido));
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePedido(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            PedidoAPIMapper mapper = new PedidoAPIMapper();
            PedidoModel pedidoModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (pedidoModel == null)
            {
                return new NotFoundResult();
            }

            bool response = _app.deleteRecordById(id);
            if (response)
            {
                return NoContent();
            }
            return StatusCode(500);
        }
    }
}
