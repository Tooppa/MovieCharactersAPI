using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.DTO.Character;

namespace MovieCharactersAPI.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Character<->CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>().ReverseMap();
            // Character<->CharacterCreateDTO
            CreateMap<Character, CharacterCreateDTO>().ReverseMap();
            // Character<->CharacterEditDTO
            CreateMap<Character, CharacterEditDTO>().ReverseMap();
        }
    }
}
