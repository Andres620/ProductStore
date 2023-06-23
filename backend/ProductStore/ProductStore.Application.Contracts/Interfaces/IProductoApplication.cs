using ProductStore.Application.Contracts.DTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Contracts.Interfaces
{
    public interface IProductoApplication
    {
        ProductoDTO getRecordById(int id);
        IEnumerable<ProductoDTO> getRecordsList();
        ProductoDTO createRecord(ProductoDTO record);
        ProductoDTO updateRecord(ProductoDTO record);
        bool deleteRecordById(int id);
    }
}
