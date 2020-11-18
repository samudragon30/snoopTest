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

    public class MediosDePagoDatos : Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMongoCollection<MediosDePago> Coleccion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public MediosDePagoDatos(string conexion, string baseDatos) : base(conexion, baseDatos)
        {
            Coleccion = contexto.db.GetCollection<MediosDePago>("MediosDePago");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> GetValidacion(Promocion p)
        {
            var filterCategorias = Builders<MediosDePago>.Filter.In(x => x.descripcion, p.MediosDePago);
            List<MediosDePago> res = await Coleccion.FindAsync(filterCategorias).Result.ToListAsync();

            return p.MediosDePago.ToArray().Length == res.Count;
        }
    }
}
