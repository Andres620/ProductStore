using Microsoft.EntityFrameworkCore;
using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Contracts.Interfaces;
using ProductStore.Repository.Implementation.DataModel;
using ProductStore.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Implementation.Core
{
    public class PedidoImpRepository : IPedidoRepository
    {
        /// <summary>
        /// Crea un pedido
        /// </summary>
        /// <param name="record">Pedido que se va a crear</param>
        /// <returns>null si el pedido ya está en el sistema o objeto pedido que se creó si no estaba en el sistema</returns>
        public PedidoDbModel createRecord(PedidoDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Pedido pedido = db.Pedidos.Where(x => x.Id.Equals(record.Id)).FirstOrDefault();
                if (pedido != null)
                {
                    return null;
                }
                PedidoRepositoryMapper mapper = new PedidoRepositoryMapper();
                Pedido pedidoRecord = mapper.DbModelToDatabaseMapper(record);
                db.Pedidos.Add(pedidoRecord);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(pedidoRecord);
            }
        }

        /// <summary>
        /// Eliminación de un registro de pedido en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                try
                {
                    Pedido record = db.Pedidos.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Pedidos.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public PedidoDbModel getRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Pedido record = db.Pedidos.Find(id);
                if (record == null)
                {
                    return null;
                }
                PedidoRepositoryMapper mapper = new PedidoRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Obtiene los registrso por Id de usuario
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public IEnumerable<PedidoDbModel> getRecordByUserId(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                IEnumerable<Pedido> list = db.Pedidos.Where(p => p.UsuarioId == id).ToList();
                PedidoRepositoryMapper mapper = new PedidoRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }


        /// <summary>
        /// Obtener la lista de pedidos
        /// </summary>
        /// <returns>Lista de registros</returns>
        public IEnumerable<PedidoDbModel> getRecordsList()
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                IEnumerable<Pedido> list = db.Pedidos.ToList();
                PedidoRepositoryMapper mapper = new PedidoRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        /// <summary>
        /// Actualiza un pedido por Id
        /// </summary>
        /// <param name="record">pedido con los datos actualizados</param>
        /// <returns>null cuando no encuentra el pedido y el pedido actualizado cuando si lo encuentra</returns>
        public PedidoDbModel updateRecord(PedidoDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Pedido pedido = db.Pedidos.Where(x => x.Id == record.Id).FirstOrDefault();
                if (pedido == null)
                {
                    return null;
                }
                else
                {
                    pedido.ProductoId = record.ProductoId;
                    pedido.Fecha = record.Fecha;
                    pedido.Cantidad = record.Cantidad;
                    db.Entry(pedido).State = EntityState.Modified;
                    db.SaveChanges();
                    PedidoRepositoryMapper mapper = new PedidoRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(pedido);
                }
            }
        }
    }
}
