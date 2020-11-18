using Microsoft.Extensions.Configuration;
using Promociones.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTestPromociones
{
    public class InitConfiguration
    {
        private IConfiguration _configuration;


        public static IConfiguration GetConfiguration()
        {
            string path = Directory.GetCurrentDirectory() + "/appsettings.test.json";
            var config = new ConfigurationBuilder()
             .AddJsonFile(path)
             .Build();

            return config;
        }

        public static Promocion PromocionInsertMock()
        {
            return new Promocion()
            {
                MediosDePago = new List<string>(){ "TARJETA_CREDITO", "TARJETA_DEBITO" },
                Bancos = new List<string>() { "ICBC", "BBVA" },
                CategoriasProductos = new List<string>() { "Hogar", "Jardin" },
                MaximaCantidadDeCuotas = 12,
                ValorInteresCuotas = Convert.ToDecimal(2.15),
                PorcentajeDeDescuento = null,
                FechaInicio = Convert.ToDateTime("2020-01-06T20:00:00Z"),
                FechaFin = Convert.ToDateTime("2020-12-06T20:00:00Z")
            };
        }

        public static Guid PromocionIdMock()
        {
            Guid id = new Guid("0e8cc3aa-4034-4f4b-b2f5-85a37973d6ce");
            return id;
        }

        public static Promocion PromocionGetMock()
        {
            return new Promocion()
            {
                Id = new Guid("0e8cc3aa-4034-4f4b-b2f5-85a37973d6ce"),
                MediosDePago = new List<string>() { "TARJETA_CREDITO", "TARJETA_DEBITO" },
                Bancos = new List<string>() { "Galicia", "Macro" },
                CategoriasProductos = new List<string>() { "Celulares", "Audio" },
                MaximaCantidadDeCuotas = 12,
                ValorInteresCuotas = Convert.ToDecimal(4.15),
                PorcentajeDeDescuento = null,
                FechaInicio = Convert.ToDateTime("2020-12-06T20:00:00Z"),
                FechaFin = Convert.ToDateTime("2030-01-06T20:00:00Z")
            };
        }
    }
}
