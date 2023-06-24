using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Repository.Contracts.DbModels.Core
{
    public class PedidoDbModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
    }
}
