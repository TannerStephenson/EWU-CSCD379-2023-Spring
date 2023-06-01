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

    public async Task<Word> GetRandomWordAsync()
    {
        var count = await _db.Words.CountAsync(word => word.IsCommon);
        var index = new Random().Next(count);
        var word = await _db.Words
          .Where(word => word.IsCommon)
          .Skip(index)
          .FirstAsync();
        return word;
    }

    public async Task<Card> GetRandomCardAsync()
    { 
        var card = await _db.Cards.FirstAsync();
        return card;
    }

}