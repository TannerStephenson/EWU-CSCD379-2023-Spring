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

    public async Task<Chip> CreateChipAsync()
    {
        var newChip = new Chip
        {
            ChipCount = DefaultChipCount // Set the default chip count
        };

        await _db.Chips.AddAsync(newChip);
        await _db.SaveChangesAsync();

        return newChip;
    }

    public async Task<int> GetChipCountAsync(Chip chip)
    {
        var result = await _db.Chips.FirstOrDefaultAsync(p => p.ChipId == chip.ChipId);
        if (result != null)
        {
            return result.ChipCount;
        }
        else
        {
            return 1000;
        }
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