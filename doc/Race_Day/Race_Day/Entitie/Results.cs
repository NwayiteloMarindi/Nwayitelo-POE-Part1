using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Entitie
{
    public class Results
    {
        [Key]
        public int ResultsId { get; set; }
        [ForeignKey("RegistrationId")]
        public int RegistrationId { get; set; }
        public required string ResultsName { get; set; }
        public required string ResultsPosition { get; set; }
        public required string ResultsTime { get; set; }
        public required string ResultsStatus { get; set; }
    }
}
