namespace Wordle.Api.Dtos
{
    public class ChipDto
    {
        public ChipDto(int chipCount)
        {
            ChipCount = chipCount;
        }

        public int ChipCount { get; set; }
    }
}
