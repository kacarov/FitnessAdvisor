using LiteDB;

namespace App.Data.Entities
{
    public class BioDataEntitie
    {
        [BsonId]
        public int BioDataId { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double NeckSize { get; set; }

        public double WaistSize { get; set; }

        public double HipsSize { get; set; }
    }
}
