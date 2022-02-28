﻿namespace MovieCharactersAPI.Models.DTO.Character
{
    public class CharacterCreateDTO
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
