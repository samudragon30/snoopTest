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

    public interface IPromocion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<respuesta.Promocion>> Get();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<respuesta.Promocion> Get(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        Task<Guid> Post(Promocion promocion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        Task Put(Promocion promocion);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(Guid id);
    }
}
