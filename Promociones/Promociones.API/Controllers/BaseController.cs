using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Promociones.Interfaces;
using Promociones.Negocios.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promociones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Global controller variables
        /// </summary>
        protected IConfiguration _configuration;
        protected string conexion;
        protected string baseDatos;
        protected IValidaciones valida;

        //
        public BaseController(IConfiguration configuration)
        {
            _configuration = configuration;
            conexion = _configuration.GetSection("MongoDB").GetSection("Conexion").Value;
            baseDatos = _configuration.GetSection("MongoDB").GetSection("BaseDeDatos").Value;
            valida = new ValidacionesBO(conexion, baseDatos);
        }
    }
}
