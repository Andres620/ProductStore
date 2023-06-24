using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Implementation.Mappers.Core
{
    public class PedidoApplicationMapper : DTOMapperBase<PedidoDTO, PedidoDbModel>
    {
        public override PedidoDTO DbModelToDTOMapper(PedidoDbModel input)
        {
            return new PedidoDTO()
            {
                Id = input.Id,
                UsuarioId = input.UsuarioId,
                ProductoId = input.ProductoId,
                Fecha = input.Fecha,
                Cantidad = input.Cantidad
            };
        }

        public override IEnumerable<PedidoDTO> DbModelToDTOMapper(IEnumerable<PedidoDbModel> input)
        {
            IList<PedidoDTO> list = new List<PedidoDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override PedidoDbModel DTOToDbModelMapper(PedidoDTO input)
        {
            return new PedidoDbModel()
            {
                Id = input.Id,
                UsuarioId = input.UsuarioId,
                ProductoId = input.ProductoId,
                Fecha = input.Fecha,
                Cantidad = input.Cantidad
            };
        }

        public override IEnumerable<PedidoDbModel> DTOToDbModelMapper(IEnumerable<PedidoDTO> input)
        {
            IList<PedidoDbModel> list = new List<PedidoDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
