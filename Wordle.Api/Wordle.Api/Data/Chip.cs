namespace Wordle.Api.Data
{
    public class Chip
    {
        public Guid ChipId { get; set; }
        public int ChipCount { get; set; }
        public string? Name { get; internal set; }
    }
}

