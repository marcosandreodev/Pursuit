using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreMongoDBCrud.Models
{
    public class Employee
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Apelido { get; set; } = "";
        public string Email { get; set; } = "";
        public string Senha { get; set; } = "";

    }
}
