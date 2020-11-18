/// <summary>
/// 
/// </summary>
namespace Promociones.Datos
{
    using MongoDB.Driver;
    using Promociones.Entidades;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoriasProductosDatos : Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMongoCollection<CategoriasProductos> Coleccion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public CategoriasProductosDatos(string conexion, string baseDatos) : base(conexion, baseDatos)
        {
            Coleccion = contexto.db.GetCollection<CategoriasProductos>("CategoriasProductos");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> GetValidacion(Promocion p)
        {
            var filterCategorias = Builders<CategoriasProductos>.Filter.In(x => x.descripcion, p.CategoriasProductos);
            List<CategoriasProductos> res = await Coleccion.FindAsync(filterCategorias).Result.ToListAsync();

            return p.CategoriasProductos.ToArray().Length == res.Count;
        }
    }
}
