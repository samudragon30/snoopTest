/// <summary>
/// 
/// </summary>
namespace Promociones.Negocios
{
    using Promociones.Datos;
    using Promociones.Entidades;
    using Promociones.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using respuesta = Promociones.DTO;

    public class PromocionVigenciaBO : IPromocionVigencia
    {
        private PromocionVigenciaData data;

        public PromocionVigenciaBO(string conexion, string baseDatos)
        {
            data = new PromocionVigenciaData(conexion, baseDatos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> GetVigencia()
        {
            return await data.GetVigencia();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> GetVigencia(DateTime fecha)
        {
            return await data.GetVigencia(fecha);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocionesParaVenta"></param>
        /// <returns></returns>
        public async Task<List<respuesta.PromocionVenta>> GetVigencia(respuesta.PromocionesParaVenta promocionesParaVenta)
        {
            return await data.GetVigencia(promocionesParaVenta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task PutVigencia(Promocion promocion)
        {
            await data.PutVigencia(promocion);
        }
    }
}
