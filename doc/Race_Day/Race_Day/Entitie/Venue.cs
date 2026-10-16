using System.ComponentModel.DataAnnotations;

namespace Race_Day.Entitie
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }
        public required string VenuesName { get; set; }
        public required string VenuesLocation { get; set; }
        public required string VenuesCity { get; set; }
        public required string VenuesCapcity { get; set; }
        public required string VenuesProvince { get; set; }
    }
}
