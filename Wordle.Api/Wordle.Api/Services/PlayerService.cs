using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    private const int DefaultChipCount = 1000;

    public PlayerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreatePlayerAsync(string playerName)
    {
        // Create the player object
        var newPlayer = new Player
        {
            Name = playerName,
            ChipCount = DefaultChipCount // Set the default chip count
        };

        // Save the new player to the database
        await _db.Players.AddAsync(newPlayer);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetChipCountAsync(Player player)
    {
        var result = await _db.Players.FirstOrDefaultAsync(p => p == player);
        return result?.ChipCount ?? 0;
    }

    public async Task SetChipCountAsync(Player player, int newChipCount)
    {
        var result = await _db.Players.FirstOrDefaultAsync(p => p == player);
        if (result != null)
        {
            result.ChipCount = newChipCount;
            _db.Players.Update(result);
        }
        await _db.SaveChangesAsync();
    }

}