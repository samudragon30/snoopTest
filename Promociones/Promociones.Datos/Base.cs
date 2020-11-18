/// <summary>
/// 
/// </summary>
namespace Promociones.Datos
{
    using MongoDB.Driver;
    using Promociones.Datos.Contexto;
    using Promociones.Datos.Herramientas;
    using Promociones.Entidades;

    public class Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected ContextoPromociones contexto;

        /// <summary>
        /// 
        /// </summary>
        protected Conversiones conversiones;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public Base(string conexion, string baseDatos)
        {
            contexto = new ContextoPromociones(conexion, baseDatos);
            conversiones = new Conversiones();
        }
    }
}
