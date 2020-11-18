using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Datos.Contexto
{
    public class ContextoPromociones
    {
        public MongoClient cliente;

        public IMongoDatabase db;

        public ContextoPromociones(string conexion, string baseDatos)
        {
            cliente = new MongoClient(conexion);

            db = cliente.GetDatabase(baseDatos);
        }
    }
}
