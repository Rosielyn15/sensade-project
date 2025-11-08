using System.Collections;

namespace SensadeProject.Models
{
    public class Parkinglot
    {
        public int? id { get; set; }
        public string? Address { get; set; }
        public string? city { get; set; }
        public string? zipcode { get; set; }
        public float? latitude { get; set; }
        public float? longitude { get; set; }
        public List<Parkingspace>? parkingspaces { get; set; } = new List<Parkingspace>();
        public int? parkinglotId { get; set; }
        public Parkinglot? parkinglot { get; set; }
    }
}
