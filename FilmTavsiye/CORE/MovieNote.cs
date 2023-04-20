using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CORE
{
    // dependent entity
    public class MovieNote
    {
        public int Id { get; set; }
        public int MovieId { get; set; } // foreign key
        [StringLength(500)]
        public string? Note { get; set; }
        public byte Score { get; set; }

        // navigation property
        [JsonIgnore]
        public Movie? Movie { get; set; }
    }
}
