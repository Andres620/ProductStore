using System;
using System.Collections.Generic;

namespace ProductStore.Repository.Implementation.DataModel;

public partial class Pedido
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public DateTime Fecha { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
