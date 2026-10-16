namespace Race_Day.Models.DTO
{
    public class Create_VenueDTO
    {
        public required string VenuesName { get; set; }
        public required string VenuesLocation { get; set; }
        public required string VenuesCity { get; set; }
        public required string VenuesCapcity { get; set; }
        public required string VenuesProvince { get; set; }
    }
}
