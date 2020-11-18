/// <summary>
/// 
/// </summary>
namespace Promociones.Datos.Herramientas
{
    using Promociones.Entidades;
    using System.Linq;
    using respuesta = Promociones.DTO;

    public class Conversiones
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public respuesta.Promocion GetPromocion(Promocion p)
        {
            return new respuesta.Promocion()
            {
                Id = p.Id,
                Activo = p.Activo,
                Bancos = p.Bancos,
                CategoriasProductos = p.CategoriasProductos,
                FechaCreacion = p.FechaCreacion,
                FechaFin = p.FechaFin,
                FechaInicio = p.FechaInicio,
                FechaModificacion = p.FechaModificacion,
                MaximaCantidadDeCuotas = p.MaximaCantidadDeCuotas,
                MediosDePago = p.MediosDePago,
                PorcentajeDeDescuento = p.PorcentajeDeDescuento,
                ValorInteresCuotas = p.ValorInteresCuotas
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public respuesta.PromocionVenta GetPromocionVenta(Promocion p)
        {
            return new respuesta.PromocionVenta()
            {
                Id = p.Id,
                ValorInteresCuotas = p.ValorInteresCuotas,
                Banco = p.Bancos.ToArray()[0],
                CategoriaProducto = p.CategoriasProductos.ToArray()[0],
                MedioDePago = p.MediosDePago.ToArray()[0],
                MaximaCantidadDeCuotas = p.MaximaCantidadDeCuotas,
                PorcentajeDeDescuento = p.PorcentajeDeDescuento
            };
        }
    }
}
