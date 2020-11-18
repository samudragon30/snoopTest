/// <summary>
/// 
/// </summary>
namespace Promociones.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Promociones.Entidades;
    using Promociones.Interfaces;
    using Promociones.Negocios;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using respuesta = Promociones.DTO;

    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private IPromocion BO;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public PromocionController(IConfiguration configuration) : base(configuration)
        {
            BO = new PromocionBO(conexion, baseDatos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<respuesta.Promocion>>> Get()
        {
            try
            {
                List<respuesta.Promocion> respuesta = await BO.Get();

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<respuesta.Promocion>> Get(Guid id)
        {
            try
            {
                respuesta.Promocion respuesta = await BO.Get(id);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(Promocion promocion)
        {
            try
            {
                if (valida.validarInsertUpdate(promocion))
                {
                    Guid id = await BO.Post(promocion);

                    return StatusCode(201, id);
                }
                else {
                    return StatusCode(422);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Put(Promocion promocion)
        {
            try
            {
                if (valida.validarInsertUpdate(promocion))
                {
                    await BO.Put(promocion);

                    return StatusCode(202);
                }
                else
                {
                    return StatusCode(422);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await BO.Delete(id);

                return StatusCode(202);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
