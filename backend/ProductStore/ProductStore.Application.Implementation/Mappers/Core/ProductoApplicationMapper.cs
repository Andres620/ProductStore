using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Implementation.Mappers.Core
{
    public class ProductoApplicationMapper : DTOMapperBase<ProductoDTO, ProductoDbModel>
    {
        public override ProductoDTO DbModelToDTOMapper(ProductoDbModel input)
        {
            return new ProductoDTO()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<ProductoDTO> DbModelToDTOMapper(IEnumerable<ProductoDbModel> input)
        {
            IList<ProductoDTO> list = new List<ProductoDTO>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDTOMapper(item));
            }
            return list;
        }

        public override ProductoDbModel DTOToDbModelMapper(ProductoDTO input)
        {
            return new ProductoDbModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<ProductoDbModel> DTOToDbModelMapper(IEnumerable<ProductoDTO> input)
        {
            IList<ProductoDbModel> list = new List<ProductoDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DTOToDbModelMapper(item));
            }
            return list;
        }
    }
}
