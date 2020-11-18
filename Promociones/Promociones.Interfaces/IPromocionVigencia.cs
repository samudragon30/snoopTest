/// <summary>
/// 
/// </summary>
namespace Promociones.Interfaces
{
    using Promociones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using respuesta = Promociones.DTO;

    public interface IPromocionVigencia
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<respuesta.Promocion>> GetVigencia();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        Task<List<respuesta.Promocion>> GetVigencia(DateTime fecha);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocionesParaVenta"></param>
        /// <returns></returns>
        Task<List<respuesta.PromocionVenta>> GetVigencia(respuesta.PromocionesParaVenta promocionesParaVenta);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        Task PutVigencia(Promocion promocion);
    }
}
