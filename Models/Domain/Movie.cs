using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(100)]
        public string? Director { get; set; }
        public string? Picture { get; set; }
        public string? Trailer { get; set; }
        public ICollection<Character>? Characters { get; set;}
        public int? FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }
    }
}
