using System;
using System.Collections.Generic;

namespace BackEndApiSimple.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
