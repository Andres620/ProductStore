using ProductStore.Application.Contracts.DTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Contracts.Interfaces
{
    public interface IPedidoApplication
    {
        PedidoDTO getRecordById(int id);
        IEnumerable<PedidoDTO> getRecordsByUserId(int id);
        IEnumerable<PedidoDTO> getRecordsList();
        PedidoDTO createRecord(PedidoDTO record);
        PedidoDTO updateRecord(PedidoDTO record);
        bool deleteRecordById(int id);
    }
}
