using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Contracts.Interfaces
{
    public interface IPedidoRepository
    {
        PedidoDbModel getRecordById(int id);
        IEnumerable<PedidoDbModel> getRecordsList();
        PedidoDbModel createRecord(PedidoDbModel record);
        PedidoDbModel updateRecord(PedidoDbModel record);
        bool deleteRecordById(int id);
    }
}
