using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.DTO
{
    public class PromocionesParaVenta
    {
        public string MedioDePago { get; set; }
        public string Banco { get; set; }
        public IEnumerable<string> CategoriasProductos { get; set; }
    }
}
