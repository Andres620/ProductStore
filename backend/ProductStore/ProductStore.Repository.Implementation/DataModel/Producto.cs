using System;
using System.Collections.Generic;

namespace ProductStore.Repository.Implementation.DataModel;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Precio { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
