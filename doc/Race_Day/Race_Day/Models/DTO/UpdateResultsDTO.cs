namespace Race_Day.Models.DTO
{
    public class UpdateResultsDTO
    {
        public required string ResultsName { get; set; }
      
        public required string ResultsPosition { get; set; }
        public required string ResultsStatus  { get; set; }
        public required string ResultsTime { get; set; }
    }
}
