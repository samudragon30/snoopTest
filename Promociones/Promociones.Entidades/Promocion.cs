using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promociones.Entidades
{
    public class Promocion
    {
        [BsonId]
        public Guid Id { get; set; }
        public IEnumerable<string> MediosDePago { get; set; }
        public IEnumerable<string> Bancos { get; set; }
        public IEnumerable<string> CategoriasProductos { get; set; }
        public int? MaximaCantidadDeCuotas { get; set; }
        public decimal? ValorInteresCuotas { get; set; }
        public decimal? PorcentajeDeDescuento { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? FechaInicio { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? FechaFin { get; set; }
        public bool Activo { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime FechaCreacion { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? FechaModificacion { get; set; }
    }
}
