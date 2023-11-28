using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Domain.Services.Communication;

namespace EFEcodrive.loyalty.Domain.Repositories;

public interface IRewardsRepository
{
    Task<IEnumerable<Rewards>> ListAsync();
    
    Task AddAsync(Rewards rewards);
    
    /*No se permite que se registren 2 rewards con el mismo name para el mismo fleetId */
    Task<Rewards> FindByRewardNameAsync(string rewardName, int fleetId);
}