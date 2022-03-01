using AutoMapper;
using MovieCharactersAPI.Models.Domain;
using MovieCharactersAPI.Models.DTO.Movie;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            // Movie<->MovieReadDTO
            CreateMap<Movie, MovieReadDTO>()
                // turn related movies into a list of ints
                .ForMember(fdto => fdto.Characters, opt => opt
                .MapFrom(f => f.Characters.Select(f => f.Id).ToList()))
                .ReverseMap();

            // Movie<->MovieCreateDTO
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            // Movie<->MovieEditDTO
            CreateMap<Movie, MovieEditDTO>().ReverseMap();
        }
    }
}
