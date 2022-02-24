namespace MovieCharactersAPI.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Gender Gender { get; set; }
        public string Picture { get; set; }
    }
}
