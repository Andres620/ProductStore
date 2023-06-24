using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Mappers
{
    public abstract class DbModelMapperBase<DbModelType, DatabaseType>
    {
        public abstract DbModelType DatabaseToDbModelMapper(DatabaseType input);
        public abstract DatabaseType DbModelToDatabaseMapper(DbModelType input);
        public abstract IEnumerable<DbModelType> DatabaseToDbModelMapper(IEnumerable<DatabaseType> input);
        public abstract IEnumerable<DatabaseType> DbModelToDatabaseMapper(IEnumerable<DbModelType> input);
    }
}
