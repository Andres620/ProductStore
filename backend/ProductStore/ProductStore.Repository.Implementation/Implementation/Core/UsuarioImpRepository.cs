using Microsoft.EntityFrameworkCore;
using ProductStore.Repository.Contracts.DbModels.Core;
using ProductStore.Repository.Contracts.Interfaces;
using ProductStore.Repository.Implementation.DataModel;
using ProductStore.Repository.Implementation.Mappers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Implementation.Implementation.Core
{
    public class UsuarioImpRepository : IUsuarioRepository
    {
        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="record">Usuario que se va a crear</param>
        /// <returns>null si el usuario ya está en el sistema o objeto usuario que se creo si no estaba en el sistema</returns>
        public UsuarioDbModel createRecord(UsuarioDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Usuario usuario = db.Usuarios.Where(x => x.CorreoElectronico.Equals(record.CorreoElectronico)).FirstOrDefault();
                if (usuario != null)
                {
                    return null;
                }
                UsuarioRepositoryMapper mapper = new UsuarioRepositoryMapper();
                Usuario usuarioRecord = mapper.DbModelToDatabaseMapper(record);
                db.Usuarios.Add(usuarioRecord);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(usuarioRecord);
            }
        }

        /// <summary>
        /// Eliminación de un registro de usuario en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                try
                {
                    Usuario record = db.Usuarios.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Usuarios.Remove(record);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Id
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public UsuarioDbModel getRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Usuario record = db.Usuarios.Find(id);
                if (record == null)
                {
                    return null;
                }
                UsuarioRepositoryMapper mapper = new UsuarioRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Obtener la lista de usuarios
        /// </summary>
        /// <returns>Lista de registros</returns>
        public IEnumerable<UsuarioDbModel> getRecordsList()
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                IEnumerable<Usuario> list = db.Usuarios.ToList();
                UsuarioRepositoryMapper mapper = new UsuarioRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        /// <summary>
        /// Actualiza un usuario por Id
        /// </summary>
        /// <param name="record">usuario con los datos actualizados</param>
        /// <returns>null cuando no encuentra al usuario y el usuario actualizado cuando si lo encuentra</returns>
        public UsuarioDbModel updateRecord(UsuarioDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Usuario usuario = db.Usuarios.Where(x => x.Id == record.Id).FirstOrDefault();
                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    usuario.Nombre = record.Nombre;
                    usuario.CorreoElectronico = record.CorreoElectronico;
                    usuario.Contrasena = record.Contrasena;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    UsuarioRepositoryMapper mapper = new UsuarioRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(usuario);
                }
            }
        }

        /// <summary>
        /// Obtiene el registro por Correo y la contraseña
        /// </summary>
        /// <param name="id">Id del registro a buscar</param>
        /// <returns>>null cuando no lo encuentra o el objeto cuando si lo encuentra</returns>
        public bool autenticateUser(string email, string password)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Usuario record = db.Usuarios.FirstOrDefault(u => u.CorreoElectronico == email && u.Contrasena == password);
                if (record == null)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
