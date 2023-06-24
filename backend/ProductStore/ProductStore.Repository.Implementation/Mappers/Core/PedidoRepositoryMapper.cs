using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Mappers.Core
{
    public class PedidoRepositoryMapper : DbModelMapperBase<PedidoDbModel, Pedido>
    {
        public override PedidoDbModel DatabaseToDbModelMapper(Pedido input)
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

        public override IEnumerable<PedidoDbModel> DatabaseToDbModelMapper(IEnumerable<Pedido> input)
        {
            IList<PedidoDbModel> list = new List<PedidoDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override Pedido DbModelToDatabaseMapper(PedidoDbModel input)
        {
            return new Pedido()
            {
                Id = input.Id,
                UsuarioId = input.UsuarioId,
                ProductoId = input.ProductoId,
                Fecha = input.Fecha,
                Cantidad = input.Cantidad
            };
        }

        public override IEnumerable<Pedido> DbModelToDatabaseMapper(IEnumerable<PedidoDbModel> input)
        {
            IList<Pedido> list = new List<Pedido>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
