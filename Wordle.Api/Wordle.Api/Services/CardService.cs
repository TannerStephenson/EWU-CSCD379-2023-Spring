using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services;

public class CardService
{
    private readonly AppDbContext _db;

    public CardService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Card> GetRandomCardAsync()
    {
        var allCards = await _db.Cards.ToListAsync();
        var randomIndex = new Random().Next(0, allCards.Count);
        var card = allCards[randomIndex];
        return card;
    }

}