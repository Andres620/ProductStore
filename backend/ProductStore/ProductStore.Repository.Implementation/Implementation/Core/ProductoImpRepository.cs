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
    public class ProductoImpRepository : IProductoRepository
    {
        /// <summary>
        /// Crea un producto
        /// </summary>
        /// <param name="record">Producto que se va a crear</param>
        /// <returns>null si el producto ya está en el sistema o objeto producto que se creó si no estaba en el sistema</returns>
        public ProductoDbModel createRecord(ProductoDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Producto producto = db.Productos.Where(x => x.Nombre.Equals(record.Nombre) && x.Descripcion.Equals(record.Descripcion)).FirstOrDefault();
                if (producto != null)
                {
                    return null;
                }
                ProductoRepositoryMapper mapper = new ProductoRepositoryMapper();
                Producto productoRecord = mapper.DbModelToDatabaseMapper(record);
                db.Productos.Add(productoRecord);
                db.SaveChanges();
                return mapper.DatabaseToDbModelMapper(productoRecord);
            }
        }

        /// <summary>
        /// Eliminación de un registro de producto en la base de datos por Id
        /// </summary>
        /// <param name="id">Id del registro a eliminar</param>
        /// <returns>Booleano, true cuando se elimina y false cuando no se encuentra o está asociado como FK</returns>
        public bool deleteRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                try
                {
                    Producto record = db.Productos.Find(id);
                    if (record == null)
                    {
                        return false;
                    }
                    db.Productos.Remove(record);
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
        public ProductoDbModel getRecordById(int id)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Producto record = db.Productos.Find(id);
                if (record == null)
                {
                    return null;
                }
                ProductoRepositoryMapper mapper = new ProductoRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(record);
            }
        }

        /// <summary>
        /// Obtener la lista de productos
        /// </summary>
        /// <returns>Lista de registros</returns>
        public IEnumerable<ProductoDbModel> getRecordsList()
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                IEnumerable<Producto> list = db.Productos.ToList();
                ProductoRepositoryMapper mapper = new ProductoRepositoryMapper();
                return mapper.DatabaseToDbModelMapper(list);
            }
        }

        /// <summary>
        /// Actualiza un producto por Id
        /// </summary>
        /// <param name="record">producto con los datos actualizados</param>
        /// <returns>null cuando no encuentra el producto y el producto actualizado cuando si lo encuentra</returns>
        public ProductoDbModel updateRecord(ProductoDbModel record)
        {
            using (ProductStoreContext db = new ProductStoreContext())
            {
                Producto producto = db.Productos.Where(x => x.Id == record.Id).FirstOrDefault();
                if (producto == null)
                {
                    return null;
                }
                else
                {
                    producto.Nombre = record.Nombre;
                    producto.Descripcion = record.Descripcion;
                    producto.Precio = record.Precio;
                    db.Entry(producto).State = EntityState.Modified;
                    db.SaveChanges();
                    ProductoRepositoryMapper mapper = new ProductoRepositoryMapper();
                    return mapper.DatabaseToDbModelMapper(producto);
                }
            }
        }
    }
}
