using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wordle.Api.Data;
using Wordle.Api.Dtos;

namespace Wordle.Api.Services;

public class ChipService
{
    private readonly AppDbContext _db;
    private const int DefaultChipCount = 1000;

    public ChipService(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateChipAsync(string ChipName)
    {
        // Create the Chip object
        var newChip = new Chip
        {
            Name = ChipName,
            ChipCount = DefaultChipCount // Set the default chip count
        };

        // Save the new Chip to the database
        await _db.Chips.AddAsync(newChip);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetChipCountAsync(Chip Chip)
    {
        var result = await _db.Chips.FirstOrDefaultAsync(p => p == Chip);
        return result?.ChipCount ?? 0;
    }

    public async Task SetChipCountAsync(Chip Chip, int newChipCount)
    {
        var result = await _db.Chips.FirstOrDefaultAsync(p => p == Chip);
        if (result != null)
        {
            result.ChipCount = newChipCount;
            _db.Chips.Update(result);
        }
        await _db.SaveChangesAsync();
    }

}