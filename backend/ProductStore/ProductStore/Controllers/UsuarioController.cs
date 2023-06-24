using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Implementation;
using ProductStore.Mappers.Core;
using ProductStore.Models.Core;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Repository.Implementation.Implementation.Core;
using System.Net;
using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Implementation.DataModel;

namespace ProductStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        //Hacer inversion de dependencias
        private IUsuarioApplication _app = new UsuarioImpApplication();

        [HttpGet]
        public ActionResult<List<UsuarioModel>> GetAllUsuarios()
        {
            UsuarioAPIMapper mapper = new UsuarioAPIMapper();
            IEnumerable<UsuarioModel> list = mapper.DTOToModelMapper(_app.getRecordsList());
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioModel> GetUsuarioById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UsuarioAPIMapper mapper = new UsuarioAPIMapper();
            UsuarioModel usuarioModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return Ok(usuarioModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UsuarioModel> CreateUsuario(UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            UsuarioAPIMapper mapper = new UsuarioAPIMapper();
            _app.createRecord(mapper.ModelToDTOMapper(usuario));

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateUsuario(UsuarioModel usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            UsuarioAPIMapper mapper = new UsuarioAPIMapper();
            UsuarioModel usuarioModel = mapper.DTOToModelMapper(_app.getRecordById(usuario.Id));
            if (usuarioModel == null)
            {
                return NotFound();
            }
            _app.updateRecord(mapper.ModelToDTOMapper(usuario));
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteUsuario(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            UsuarioAPIMapper mapper = new UsuarioAPIMapper();
            UsuarioModel usuarioModel = mapper.DTOToModelMapper(_app.getRecordById(id));
            if (usuarioModel == null)
            {
                return NotFound();
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
