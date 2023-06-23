using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Implementation.Mappers.Core
{
    public class UsuarioApplicationMapper : DTOMapperBase<UsuarioDTO, UsuarioDbModel>
    {
        public override UsuarioDTO DbModelToDTOMapper(UsuarioDbModel input)
        {
            return new UsuarioDTO()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<UsuarioDTO> DbModelToDTOMapper(IEnumerable<UsuarioDbModel> input)
        {
            IList<UsuarioDTO> list = new List<UsuarioDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override UsuarioDbModel DTOToDbModelMapper(UsuarioDTO input)
        {
            return new UsuarioDbModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<UsuarioDbModel> DTOToDbModelMapper(IEnumerable<UsuarioDTO> input)
        {
            IList<UsuarioDbModel> list = new List<UsuarioDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
