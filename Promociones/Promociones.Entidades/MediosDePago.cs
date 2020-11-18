using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Entidades
{
    public class MediosDePago
    {
        [BsonId]
        public Guid Id { get; set; }
        public string descripcion { get; set; }
    }
}
