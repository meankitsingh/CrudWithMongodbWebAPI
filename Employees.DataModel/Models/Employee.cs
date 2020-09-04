using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Employees.DataModel
{
    public class Employee
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contact { get; set; }

    }
}