using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Dtos;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
            private readonly CardService _cardService;

            public CardController(CardService cardService)
            {
                _cardService = cardService;
            }

            [HttpGet]
            public async Task<CardDto> Get()
            {
                var randomCard = await _cardService.GetRandomCardAsync();
                // Map the Card object to a CardDto object
                var cardDto = new CardDto
                {
                    Suit = randomCard.Suit,
                    CardValue = randomCard.CardValue
                };
                return cardDto;
            }
    }
}
