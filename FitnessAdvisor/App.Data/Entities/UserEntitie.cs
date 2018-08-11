using LiteDB;

namespace App.Data.Entities
{
    public class UserEntitie
    {
        [BsonId]
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //[BsonRef]
        public BioDataEntitie BioData { get; set; }
    }
}
