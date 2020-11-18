/// <summary>
/// 
/// </summary>
namespace Promociones.Negocios.Herramientas
{
    using Promociones.Datos;
    using Promociones.Entidades;
    using Promociones.Interfaces;
    using System;
    using System.Linq;

    public class ValidacionesBO : IValidaciones
    {
        private BancosDatos dataBancos;

        private CategoriasProductosDatos dataCategoriasProductos;

        private MediosDePagoDatos dataMediosDePago;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="baseDatos"></param>
        public ValidacionesBO(string conexion, string baseDatos)
        {
            dataBancos = new BancosDatos(conexion, baseDatos);
            dataCategoriasProductos = new CategoriasProductosDatos(conexion, baseDatos);
            dataMediosDePago = new MediosDePagoDatos(conexion, baseDatos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool validarInsertUpdate(Promocion p)
        {
            bool validar = true;

            if (p.MaximaCantidadDeCuotas == null && p.PorcentajeDeDescuento == null)
            {
                validar = false;
            }

            if (p.ValorInteresCuotas != null && p.MaximaCantidadDeCuotas == null)
            {
                validar = false;
            }

            if (p.PorcentajeDeDescuento != null && (p.PorcentajeDeDescuento < 5 || p.PorcentajeDeDescuento > 80))
            {
                validar = false;
            }

            if (p.FechaFin != null && p.FechaInicio != null)
            {
                if (DateTime.Compare(Convert.ToDateTime(p.FechaInicio), Convert.ToDateTime(p.FechaFin)) > 0)
                {
                    validar = false;
                }
            }

            if (p.PorcentajeDeDescuento != null && p.MaximaCantidadDeCuotas != null)
            {
                validar = false;
            }

            if (p.Bancos.ToArray().Length > 0 && !dataBancos.GetValidacion(p).Result)
            {

                validar = false;
            }

            if (p.CategoriasProductos.ToArray().Length > 0 && !dataCategoriasProductos.GetValidacion(p).Result)
            {
                validar = false;
            }

            if (p.MediosDePago.ToArray().Length > 0 && !dataMediosDePago.GetValidacion(p).Result)
            {
                validar = false;
            }

            return validar;
        }
    }
}
