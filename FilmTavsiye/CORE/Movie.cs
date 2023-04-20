using System.ComponentModel.DataAnnotations;

namespace CORE
{
    // principal entity
    public class Movie
    {
        public int Id { get; set; } // principal key
        [StringLength(100)]
        public string? PosterPath { get; set; }
        public bool Adult { get; set; }
        [StringLength(1000)]
        public string? Overview { get; set; }
        [StringLength(10)]
        public string? ReleaseDate { get; set; }
        public List<int> GenreIds { get; set; }
        public int TmdbId { get; set; }
        [StringLength(150)]
        public string? OriginalTitle { get; set; }
        [StringLength(2)]
        public string? OriginalLanguage { get; set; }
        [StringLength(150)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? BackdropPath { get; set; }
        public double Popularity { get; set; }
        public int VoteCount { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }

        // navigation property
        public ICollection<MovieNote> MovieNotes { get; set; }
    }
}
