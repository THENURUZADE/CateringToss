using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFT.DB.Entity
{
    public class Chief : BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
      
        [BsonElement("effectivedate")]
        public DateTime EffectiveDate { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
