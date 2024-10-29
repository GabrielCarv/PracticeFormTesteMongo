using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FormForTestWithMongo.Models
{
    public class User
    {
        [BsonId] // Isso indica que o MongoDB vai usar este campo como o ID
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Phone")]
        public string Phone { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("City")]
        public string City { get; set; }
    }
}
