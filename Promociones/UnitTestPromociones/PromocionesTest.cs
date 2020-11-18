using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Promociones.Entidades;
using Promociones.Interfaces;
using Promociones.Negocios;
using Promociones.Negocios.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestPromociones;
using respuesta = Promociones.DTO;

namespace PromocionesTest
{
    [TestClass]
    public class PromocionesTest
    {
        private IConfiguration _configuration;
        private IPromocion BO;
        private IValidaciones valida;

        [TestInitialize]
        public void TestInitialization()
        {
            _configuration = InitConfiguration.GetConfiguration();
            string conexion = _configuration.GetSection("MongoDB").GetSection("Conexion").Value;
            string baseDatos = _configuration.GetSection("MongoDB").GetSection("BaseDeDatos").Value;
            BO = new PromocionBO(conexion, baseDatos);
            valida = new ValidacionesBO(conexion, baseDatos);
        }

        [TestMethod]
        public async Task Gets_Id_Insert_correct()
        {
            Guid id = await BO.Post(InitConfiguration.PromocionInsertMock());
            Assert.IsNotNull(id);
        }

        [TestMethod]
        public async Task Gets_Data_By_Id_correct()
        {
            Guid id = InitConfiguration.PromocionIdMock();
            respuesta.Promocion p = await BO.Get(id);
            Assert.AreEqual(id, p.Id);
        }

        [TestMethod]
        public async Task Gets_Valid_Insert_Validation()
        {
            Promocion p = InitConfiguration.PromocionInsertMock();
            Assert.IsTrue(valida.validarInsertUpdate(p));
        }

        [TestMethod]
        public async Task Gets_Invalid_Banks_Validation()
        {
            Promocion p = InitConfiguration.PromocionInsertMock();
            List<string> lista = p.Bancos.ToList();
            lista.Add("BCRA");
            p.Bancos = lista;
            Assert.IsFalse(valida.validarInsertUpdate(p));
        }

        [TestMethod]
        public async Task Gets_Invalid_Payment_Methods_Validation()
        {
            Promocion p = InitConfiguration.PromocionInsertMock();
            List<string> lista = p.MediosDePago.ToList();
            lista.Add("Paypal");
            p.MediosDePago = lista;
            Assert.IsFalse(valida.validarInsertUpdate(p));
        }

        [TestMethod]
        public async Task Gets_Invalid_Categories_Validation()
        {
            Promocion p = InitConfiguration.PromocionInsertMock();
            List<string> lista = p.CategoriasProductos.ToList();
            lista.Add("Juguetes");
            p.CategoriasProductos = lista;
            Assert.IsFalse(valida.validarInsertUpdate(p));
        }
    }
}
