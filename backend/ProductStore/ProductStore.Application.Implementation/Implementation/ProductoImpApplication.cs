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
    public class ProductoImpApplication : IProductoApplication
    {
        IProductoRepository _repository;

        public ProductoImpApplication(IProductoRepository repository)
        {
            _repository = repository;
        }

        public ProductoDTO createRecord(ProductoDTO record)
        {
            ProductoApplicationMapper mapper = new ProductoApplicationMapper();
            ProductoDbModel dbModel = mapper.DTOToDbModelMapper(record);
            ProductoDbModel response = this._repository.createRecord(dbModel);
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

        public ProductoDTO getRecordById(int id)
        {
            ProductoApplicationMapper mapper = new ProductoApplicationMapper();
            ProductoDbModel dbModel = _repository.getRecordById(id);
            if (dbModel == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(dbModel);
        }

        public IEnumerable<ProductoDTO> getRecordsList()
        {
            ProductoApplicationMapper mapper = new ProductoApplicationMapper();
            IEnumerable<ProductoDbModel> dbModelList = _repository.getRecordsList();
            return mapper.DbModelToDTOMapper(dbModelList);
        }

        public ProductoDTO updateRecord(ProductoDTO record)
        {
            ProductoApplicationMapper mapper = new ProductoApplicationMapper();
            ProductoDbModel dbModel = mapper.DTOToDbModelMapper(record);
            ProductoDbModel response = this._repository.updateRecord(dbModel);
            if (response == null)
            {
                return null;
            }
            return mapper.DbModelToDTOMapper(response);
        }
    }
}
