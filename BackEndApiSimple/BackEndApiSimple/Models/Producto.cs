using System;
using System.Collections.Generic;

namespace BackEndApiSimple.Models;

public partial class Producto
{
    public int Id { get; set; }

    public int IdCateg { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Categoria IdCategNavigation { get; set; } = null!;
}
