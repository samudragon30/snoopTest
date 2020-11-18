using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.DTO
{
    public class PromocionVenta
    {
        public Guid Id { get; set; }
        public string MedioDePago { get; set; }
        public string Banco { get; set; }
        public string CategoriaProducto { get; set; }
        public int? MaximaCantidadDeCuotas { get; set; }
        public decimal? ValorInteresCuotas { get; set; }
        public decimal? PorcentajeDeDescuento { get; set; }

    }
}
