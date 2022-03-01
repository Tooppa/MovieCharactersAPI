using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.DTO.Franchise;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            // Franchise<->FranchiseReadDTO
            CreateMap<Franchise, FranchiseReadDTO>()
                // turn related movies into a list of ints
                .ForMember(fdto => fdto.Movies, opt => opt
                .MapFrom(f => f.Movies.Select(f => f.Id).ToList()))
                .ReverseMap();
            // Franchise<->FranchiseCreateDTO
            CreateMap<Character, FranchiseCreateDTO>().ReverseMap();
            // Franchise<->FranchiseEditDTO
            CreateMap<Character, FranchiseEditDTO>().ReverseMap();
        }
    }
}
