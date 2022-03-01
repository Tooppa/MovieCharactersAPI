using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.DTO.Movie;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            // Movie<->MovieReadDTO
            CreateMap<Movie, MovieReadDTO>().ReverseMap();
            // Movie<->MovieCreateDTO
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            // Movie<->MovieEditDTO
            CreateMap<Movie, MovieEditDTO>().ReverseMap();
        }
    }
}
