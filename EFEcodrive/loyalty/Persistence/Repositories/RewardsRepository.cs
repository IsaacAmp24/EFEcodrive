using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Domain.Repositories;
using EFEcodrive.Shared.Persistence.Contexts;
using EFEcodrive.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace EFEcodrive.loyalty.Persistence.Repositories;

public class RewardsRepository : BaseRepository, IRewardsRepository
{
    public RewardsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Rewards>> ListAsync()
    {
        return await _context.Rewards.ToListAsync();
    }

    public async Task AddAsync(Rewards rewards)
    {
        await _context.Rewards.AddAsync(rewards);
    }

    public async Task<Rewards> FindByRewardNameAsync(string rewardName, int fleetId)
    {
        // No se permite que se registren 2 rewards con el mismo name para el mismo fleetId
        return await _context.Rewards.FirstOrDefaultAsync(r => r.RewardName == rewardName && r.fleetId == fleetId);
    }
}