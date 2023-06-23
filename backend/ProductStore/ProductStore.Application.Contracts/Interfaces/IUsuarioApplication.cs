using ProductStore.Application.Contracts.DTO.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Contracts.Interfaces
{
    public interface IUsuarioApplication
    {
        UsuarioDTO getRecordById(int id);
        IEnumerable<UsuarioDTO> getRecordsList();
        UsuarioDTO createRecord(UsuarioDTO record);
        UsuarioDTO updateRecord(UsuarioDTO record);
        bool deleteRecordById(int id);
    }
}
