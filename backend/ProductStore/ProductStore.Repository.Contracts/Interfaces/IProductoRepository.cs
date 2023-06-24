using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Contracts.Interfaces
{
    public interface IProductoRepository
    {
        ProductoDbModel getRecordById(int id);
        IEnumerable<ProductoDbModel> getRecordsList();
        ProductoDbModel createRecord(ProductoDbModel record);
        ProductoDbModel updateRecord(ProductoDbModel record);
        bool deleteRecordById(int id);
    }
}
