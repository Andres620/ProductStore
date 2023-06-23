namespace ProductStore.Models.Core
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
    }
}
