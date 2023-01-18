using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Labb3
{
    internal class ProductODM
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement ("name")]
        public string Name { get; set; }

        [BsonElement ("amount")]
        public int Amount { get; set; }

        [BsonElement ("description")]
        public string Description { get; set; }
    }
}
