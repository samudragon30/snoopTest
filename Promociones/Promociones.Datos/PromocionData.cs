/// <summary>
/// 
/// </summary>
namespace Promociones.Datos
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Promociones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using respuesta = Promociones.DTO;

    public class PromocionData : Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMongoCollection<Promocion> Coleccion;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public PromocionData(string conexion, string baseDatos) : base(conexion, baseDatos)
        {
            Coleccion = contexto.db.GetCollection<Promocion>("Promocion");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task<Guid> Post(Promocion promocion)
        {
            promocion.FechaCreacion = DateTime.Now;
            promocion.FechaModificacion = DateTime.Now;
            promocion.Activo = true;
            await Coleccion.InsertOneAsync(promocion);
            return promocion.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task Put(Promocion promocion)
        {
            promocion.FechaModificacion = DateTime.Now;
            var filter = Builders<Promocion>.Filter.Eq(x => x.Id, promocion.Id);

            await Coleccion.ReplaceOneAsync(filter, promocion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> Get()
        {
            List<Promocion> lista = await Coleccion.FindAsync(new BsonDocument()).Result.ToListAsync();

            List<respuesta.Promocion> promociones = new List<respuesta.Promocion>();

            foreach (Promocion promo in lista)
            {
                promociones.Add(conversiones.GetPromocion(promo));
            }

            return promociones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Promocion> GetById(Guid id)
        {
            return await Coleccion.FindAsync(x => x.Id == id).Result.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            Promocion p = GetById(id).Result;
            p.Activo = false;
            p.FechaModificacion = DateTime.Now;
            await Put(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<respuesta.Promocion> Get(Guid id)
        {
            Promocion p = await Coleccion.FindAsync(x => x.Id == id).Result.FirstOrDefaultAsync();

            return conversiones.GetPromocion(p);
        }
    }
}
