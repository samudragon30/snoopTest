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

    public class PromocionBO : IPromocion
    {
        /// <summary>
        /// 
        /// </summary>
        private PromocionData data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public PromocionBO(string conexion, string baseDatos)
        {
            data = new PromocionData(conexion, baseDatos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task<Guid> Post(Promocion promocion)
        {
            return await data.Post(promocion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task Put(Promocion promocion)
        {
            await data.Put(promocion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> Get()
        {
            return await data.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<respuesta.Promocion> Get(Guid id)
        {
            return await data.Get(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            await data.Delete(id);
        }
    }
}
