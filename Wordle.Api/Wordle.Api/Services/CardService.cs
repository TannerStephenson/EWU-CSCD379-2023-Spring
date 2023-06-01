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
        var randomIndex = new Random().Next(1, 52);
        /*var card = await _db.Cards.FirstAsync();*/
        var card = await _db.Cards.Skip(randomIndex).FirstAsync();
        return card;
    }

}