using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Mappers.Core
{
    public class UsuarioRepositoryMapper : DbModelMapperBase<UsuarioDbModel, Usuario>
    {
        public override UsuarioDbModel DatabaseToDbModelMapper(Usuario input)
        {
            return new UsuarioDbModel()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<UsuarioDbModel> DatabaseToDbModelMapper(IEnumerable<Usuario> input)
        {
            IList<UsuarioDbModel> list = new List<UsuarioDbModel>();
            foreach (var item in input)
            {
                list.Add(this.DatabaseToDbModelMapper(item));
            }
            return list;
        }

        public override Usuario DbModelToDatabaseMapper(UsuarioDbModel input)
        {
            return new Usuario()
            {
                Id = input.Id,
                Nombre = input.Nombre,
                CorreoElectronico = input.CorreoElectronico,
                Contrasena = input.Contrasena
            };
        }

        public override IEnumerable<Usuario> DbModelToDatabaseMapper(IEnumerable<UsuarioDbModel> input)
        {
            IList<Usuario> list = new List<Usuario>();
            foreach (var item in input)
            {
                list.Add(this.DbModelToDatabaseMapper(item));
            }
            return list;
        }
    }
}
