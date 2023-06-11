namespace Wordle.Api.Data
{
    public class Card
    {
        public int Id { get; set; }
        public string? Suit { get; set; }
        public int CardValue { get; set; }
        public string? Character { get; set; }
    }
}

