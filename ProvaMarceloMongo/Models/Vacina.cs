using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaMarceloMongo.Models
{
    [BsonIgnoreExtraElements]
    public class Vacina
    {
        public ObjectId Id { get; set; }
        [Required]
        public int  Id_Animal { get; set; }
        public double peso { get; set; }
        public double dosagem { get; set; }
        public string aplicador { get; set; }
        public string descricao_medicamento { get; set; }
       
    }

}


