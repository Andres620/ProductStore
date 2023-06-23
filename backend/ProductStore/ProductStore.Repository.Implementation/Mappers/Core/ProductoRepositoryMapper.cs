using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Mappers.Core
{
    public class ProductoRepositoryMapper : DbModelMapperBase<ProductoDbModel, Producto>
    {
        public override ProductoDbModel DatabaseToDbModelMapper(Producto input)
        {
            return new ProductoDbModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<ProductoDbModel> DatabaseToDbModelMapper(IEnumerable<Producto> input)
        {
            IList<ProductoDbModel> list = new List<ProductoDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override Producto DbModelToDatabaseMapper(ProductoDbModel input)
        {
            return new Producto() 
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                Precio = input.Precio
            };
        }

        public override IEnumerable<Producto> DbModelToDatabaseMapper(IEnumerable<ProductoDbModel> input)
        {
            IList<Producto> list = new List<Producto>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
