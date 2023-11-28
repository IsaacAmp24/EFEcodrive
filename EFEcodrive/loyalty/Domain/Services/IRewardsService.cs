using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Domain.Services.Communication;

namespace EFEcodrive.loyalty.Domain.Services;

public interface IRewardsService
{
    // ListAsync (GET) - obtener de la base de datos
    Task<IEnumerable<Rewards>> ListAsync();
    
    // SaveAsync (POST) - guardar en la base de datos
    Task<RewardsResponse> SaveAsync(Rewards rewards);
}