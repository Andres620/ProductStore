using ProductStore.Application.Contracts.DTO.Core;
using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Mappers.Core;
using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Contracts.Interfaces;

namespace ProductStore.Application.Implementation.Implementation
{
    public class PedidoImpApplication : IPedidoApplication
    {
        IPedidoRepository _repository;

        public PedidoImpApplication(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public PedidoDTO createRecord(PedidoDTO record)
        {
            PedidoApplicationMapper mapper = new PedidoApplicationMapper();
            PedidoDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PedidoDbModel response = this._repository.createRecord(dbModel);
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

        public PedidoDTO getRecordById(int id)
        {
            PedidoApplicationMapper mapper = new PedidoApplicationMapper();
            PedidoDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<PedidoDTO> getRecordsList()
        {
            PedidoApplicationMapper mapper = new PedidoApplicationMapper();
            IEnumerable<PedidoDbModel> dbModelList = _repository.getRecordsList();
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public PedidoDTO updateRecord(PedidoDTO record)
        {
            PedidoApplicationMapper mapper = new PedidoApplicationMapper();
            PedidoDbModel dbModel = mapper.DTOToDbModelMapper(record);
            PedidoDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
