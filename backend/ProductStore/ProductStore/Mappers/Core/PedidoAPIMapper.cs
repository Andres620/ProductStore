using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Models.Core;

namespace ProductStore.Mappers.Core
{
    public class PedidoAPIMapper : ModelMapperBase<PedidoModel, PedidoDTO>
    {
        public override PedidoModel DTOToModelMapper(PedidoDTO input)
        {
            return new PedidoModel
            {
                Id = input.Id,
                UsuarioId = input.UsuarioId,
                ProductoId = input.ProductoId,
                Fecha = input.Fecha,
                Cantidad = input.Cantidad
            };
        }

        public override IEnumerable<PedidoModel> DTOToModelMapper(IEnumerable<PedidoDTO> input)
        {
            IList<PedidoModel> list = new List<PedidoModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override PedidoDTO ModelToDTOMapper(PedidoModel input)
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

        public override IEnumerable<PedidoDTO> ModelToDTOMapper(IEnumerable<PedidoModel> input)
        {
            IList<PedidoDTO> list = new List<PedidoDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
