using System.Reflection.PortableExecutable;

namespace Wordle.Api.Dtos
{
    public class CardDto
    {
        public int Id { get; set; }
        public string? Suit { get; set; }
        public int CardValue { get; set; }
        public string? Character { get; set; }
    }
}
