namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public PlayerDto(int chipCount)
        {
            ChipCount = chipCount;
        }

        public int ChipCount { get; set; }
    }
}
