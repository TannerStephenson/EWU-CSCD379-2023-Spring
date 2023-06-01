using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Services;
using System.Threading.Tasks;

namespace Wordle.Api.Controllers
{
    [Route("[controller]")]
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