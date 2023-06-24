using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Implementation;
using ProductStore.Mappers.Core;
using ProductStore.Models.Core;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private IProductoApplication _app;

        public ProductoController(IProductoApplication app)
        {
            _app = app;
        }

        [HttpGet]
        public ActionResult<List<ProductoModel>> GetAllProductos()
        {
            ProductoAPIMapper mapper = new ProductoAPIMapper();
            IEnumerable<ProductoModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return Ok(list);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductoModel> GetProductoById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ProductoAPIMapper mapper = new ProductoAPIMapper();
            ProductoModel productoModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (productoModel == null)
            {
                return NotFound();
            }
            return Ok(productoModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductoModel> CreateProducto(ProductoModel producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }
            ProductoAPIMapper mapper = new ProductoAPIMapper();
            _app.createRecord(mapper.ModelToDTOMapper(producto));

            return Ok(producto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProducto(ProductoModel producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            ProductoAPIMapper mapper = new ProductoAPIMapper();
            ProductoModel productoModel = mapper.DTOToModelMapper(_app.getRecordById(producto.Id));
            if (productoModel == null)
            {
                return NotFound();
            }
            _app.updateRecord(mapper.ModelToDTOMapper(producto));
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProducto(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ProductoAPIMapper mapper = new ProductoAPIMapper();
            ProductoModel productoModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (productoModel == null)
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
