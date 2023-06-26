using ProductStore.Repository.Contracts.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Contracts.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDbModel getRecordById(int id);
        IEnumerable<UsuarioDbModel> getRecordsList();
        UsuarioDbModel createRecord(UsuarioDbModel record);
        UsuarioDbModel updateRecord(UsuarioDbModel record);
        bool deleteRecordById(int id);
        bool autenticateUser(string email, string password);
    }
}
