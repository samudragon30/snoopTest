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

    public class BancosDatos : Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMongoCollection<Bancos> Coleccion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public BancosDatos(string conexion, string baseDatos) : base(conexion, baseDatos)
        {
            Coleccion = contexto.db.GetCollection<Bancos>("Bancos");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> GetValidacion(Promocion p)
        {
            var filterCategorias = Builders<Bancos>.Filter.In(x => x.descripcion, p.Bancos);
            List<Bancos> res = await Coleccion.FindAsync(filterCategorias).Result.ToListAsync();
            
            return p.Bancos.ToArray().Length == res.Count;
        }
    }
}
