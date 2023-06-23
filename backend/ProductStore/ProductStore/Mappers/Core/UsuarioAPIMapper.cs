using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Models.Core;

namespace ProductStore.Mappers.Core
{
    public class UsuarioAPIMapper : ModelMapperBase<UsuarioModel, UsuarioDTO>
    {
        public override UsuarioModel DTOToModelMapper(UsuarioDTO input)
        {
            return new UsuarioModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<UsuarioModel> DTOToModelMapper(IEnumerable<UsuarioDTO> input)
        {
            IList<UsuarioModel> list = new List<UsuarioModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override UsuarioDTO ModelToDTOMapper(UsuarioModel input)
        {
            return new UsuarioDTO()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<UsuarioDTO> ModelToDTOMapper(IEnumerable<UsuarioModel> input)
        {
            IList<UsuarioDTO> list = new List<UsuarioDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
