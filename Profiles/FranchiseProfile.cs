using AutoMapper;
using MovieCharactersAPI.Models.Domain;
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
                .MapFrom(f => f.Movies.Select(m => m.Id).ToList()))
                .ReverseMap();
            // Franchise<->FranchiseCreateDTO
            CreateMap<Franchise, FranchiseCreateDTO>().ReverseMap();
            // Franchise<->FranchiseEditDTO
            CreateMap<Franchise, FranchiseEditDTO>().ReverseMap();
        }
    }
}
