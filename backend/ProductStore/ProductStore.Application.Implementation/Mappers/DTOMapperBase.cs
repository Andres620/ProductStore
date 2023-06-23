using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Application.Implementation.Mappers
{
    public abstract class DTOMapperBase<DTOType, DbModelType>
    {
        public abstract DTOType DbModelToDTOMapper(DbModelType input);
        public abstract DbModelType DTOToDbModelMapper(DTOType input);
        public abstract IEnumerable<DTOType> DbModelToDTOMapper(IEnumerable<DbModelType> input);
        public abstract IEnumerable<DbModelType> DTOToDbModelMapper(IEnumerable<DTOType> input);
    }
}
