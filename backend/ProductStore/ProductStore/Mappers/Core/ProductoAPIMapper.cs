using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Models.Core;

namespace ProductStore.Mappers.Core
{
    public class ProductoAPIMapper : ModelMapperBase<ProductoModel, ProductoDTO>
    {
        public override ProductoModel DTOToModelMapper(ProductoDTO input)
        {
            return new ProductoModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<ProductoModel> DTOToModelMapper(IEnumerable<ProductoDTO> input)
        {
            IList<ProductoModel> list = new List<ProductoModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToModelMapper(item));
            }
            return list;
        }

        public override ProductoDTO ModelToDTOMapper(ProductoModel input)
        {
            return new ProductoDTO()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<ProductoDTO> ModelToDTOMapper(IEnumerable<ProductoModel> input)
        {
            IList<ProductoDTO> list = new List<ProductoDTO>();
            foreach (var item in input)
            {
                list.Add(this.ModelToDTOMapper(item));
            }
            return list;
        }
    }
}
