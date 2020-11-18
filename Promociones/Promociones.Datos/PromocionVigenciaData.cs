/// <summary>
/// 
/// </summary>
namespace Promociones.Datos
{
    using MongoDB.Driver;
    using Promociones.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using respuesta = Promociones.DTO;
    public class PromocionVigenciaData : Base
    {
        /// <summary>
        /// 
        /// </summary>
        protected IMongoCollection<Promocion> Coleccion;

        /// <summary>
        /// 
        /// </summary>
        private PromocionData pd;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public PromocionVigenciaData(string conexion, string baseDatos) : base(conexion, baseDatos)
        {
            Coleccion = contexto.db.GetCollection<Promocion>("Promocion");
            pd = new PromocionData(conexion, baseDatos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> GetVigencia()
        {
            List<Promocion> lista = await Coleccion.FindAsync(x => x.FechaFin >= DateTime.Now).Result.ToListAsync();

            List<respuesta.Promocion> promociones = new List<respuesta.Promocion>();

            foreach (Promocion p in lista)
            {
                promociones.Add(conversiones.GetPromocion(p));
            }

            return promociones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<List<respuesta.Promocion>> GetVigencia(DateTime fecha)
        {
            List<Promocion> lista = await Coleccion.FindAsync(x => x.FechaFin >= fecha && x.FechaInicio <= fecha).Result.ToListAsync();
            
            List<respuesta.Promocion> promociones = new List<respuesta.Promocion>();

            foreach (Promocion p in lista)
            {
                promociones.Add(conversiones.GetPromocion(p));
            }

            return promociones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<List<respuesta.PromocionVenta>> GetVigencia(respuesta.PromocionesParaVenta p)
        {
            
            var filterPago = Builders<Promocion>.Filter.ElemMatch(x => x.MediosDePago, x => x.Contains(p.MedioDePago));
            var filterBanco = Builders<Promocion>.Filter.ElemMatch(x => x.Bancos, x => x.Contains(p.Banco));
            var filterCategorias =  Builders<Promocion>.Filter.AnyIn(x => x.CategoriasProductos, p.CategoriasProductos);
            var combineFilters = Builders<Promocion>.Filter.And(filterPago, filterBanco, filterCategorias);
            List<Promocion> res = await Coleccion.FindAsync(combineFilters).Result.ToListAsync();

            List<respuesta.PromocionVenta> promociones = new List<respuesta.PromocionVenta>();

            foreach (Promocion promo in res)
            {
                promociones.Add(conversiones.GetPromocionVenta(promo));
            }

            return promociones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="promocion"></param>
        /// <returns></returns>
        public async Task PutVigencia(Promocion promocion)
        {
            
            Promocion p = pd.GetById(promocion.Id).Result;
            p.Activo = false;
            p.FechaInicio = promocion.FechaInicio;
            p.FechaFin = promocion.FechaFin;
            await pd.Put(p);
        }
    }
}
