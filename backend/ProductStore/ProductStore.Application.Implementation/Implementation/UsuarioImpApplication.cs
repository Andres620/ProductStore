using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Mappers.Core;
using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Contracts.Interfaces;
using ProductStore.Repository.Implementation.Implementation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Implementation.Implementation
{
    public class UsuarioImpApplication : IUsuarioApplication
    {
        IUsuarioRepository _repository;

        public UsuarioImpApplication(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioDTO createRecord(UsuarioDTO record)
        {
            UsuarioApplicationMapper mapper = new UsuarioApplicationMapper();
            UsuarioDbModel dbModel = mapper.DTOToDbModelMapper(record);
            UsuarioDbModel response = this._repository.createRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }

        public bool deleteRecordById(int id)
        {
            return _repository.deleteRecordById(id);
        }

        public UsuarioDTO getRecordById(int id)
        {
            UsuarioApplicationMapper mapper = new UsuarioApplicationMapper();
            UsuarioDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<UsuarioDTO> getRecordsList()
        {
            UsuarioApplicationMapper mapper = new UsuarioApplicationMapper();
            IEnumerable<UsuarioDbModel> dbModelList = _repository.getRecordsList();
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public UsuarioDTO updateRecord(UsuarioDTO record)
        {
            UsuarioApplicationMapper mapper = new UsuarioApplicationMapper();
            UsuarioDbModel dbModel = mapper.DTOToDbModelMapper(record);
            UsuarioDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
