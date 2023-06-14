namespace Wordle.Api.Data
{
    public class Player
    {
        public Guid PlayerId { get; set; }
        public int ChipCount { get; set; }
        public string? Name { get; internal set; }
    }
}

