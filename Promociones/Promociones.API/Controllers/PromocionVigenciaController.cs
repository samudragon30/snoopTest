using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Promociones.Interfaces;
using Promociones.Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using respuesta = Promociones.DTO;
using Promociones.Entidades;

namespace Promociones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionVigenciaController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private IPromocionVigencia BO;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public PromocionVigenciaController(IConfiguration configuration) : base(configuration)
        {
            BO = new PromocionVigenciaBO(conexion, baseDatos);
        }

        [HttpGet]
        public async Task<ActionResult<List<respuesta.Promocion>>> Get()
        {
            try
            {
                List<respuesta.Promocion> respuesta = await BO.GetVigencia();

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<List<respuesta.Promocion>>> Get(DateTime date)
        {
            try
            {
                List<respuesta.Promocion> respuesta = await BO.GetVigencia(date);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<respuesta.PromocionVenta>>> Post(respuesta.PromocionesParaVenta promocion)
        {
            try
            {
                List<respuesta.PromocionVenta> respuesta = await BO.GetVigencia(promocion);

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Promocion promocion)
        {
            try
            {
                if (valida.validarInsertUpdate(promocion))
                {
                    await BO.PutVigencia(promocion);

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
    }
}
