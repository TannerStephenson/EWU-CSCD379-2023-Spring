using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
            private readonly PlayerService _playerService;

            public PlayerController(PlayerService playerService)
            {
                _playerService = playerService;
            }

        [HttpGet]
        public async Task<PlayerDto> Get()
        {
            var player = new Player();
            int chipCount = await _playerService.GetChipCountAsync(player);
            var dto = new PlayerDto(chipCount);
            return dto;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayerDto dto)
        {
            var player = new Player();
            await _playerService.SetChipCountAsync(player, dto.ChipCount);
            return Ok();
        }

    }
}
