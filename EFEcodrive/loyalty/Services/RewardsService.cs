using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Domain.Repositories;
using EFEcodrive.loyalty.Domain.Services;
using EFEcodrive.loyalty.Domain.Services.Communication;
using EFEcodrive.Shared.Domain.Repositories;

namespace EFEcodrive.loyalty.Services;

public class RewardsService : IRewardsService
{
    private readonly IRewardsRepository _rewardsRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public RewardsService(IRewardsRepository rewardsRepository, IUnitOfWork unitOfWork)
    {
        _rewardsRepository = rewardsRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Rewards>> ListAsync()
    {
        return await _rewardsRepository.ListAsync();
    }

    public async Task<RewardsResponse> SaveAsync(Rewards rewards)
    {
        // No permite que se registre dos rewards con el mismo name para el mismo fleetId.
        var existingReward = await _rewardsRepository.FindByRewardNameAsync(rewards.RewardName, rewards.fleetId);
        
        if (existingReward != null)
            return new RewardsResponse("Reward name already exists for this fleet");
        
        // No permite que se registre un reward con un valor de score cero (0).
        if (rewards.score <= 0)
            return new RewardsResponse("Score must be greater than 0");

        try
        {
            await _rewardsRepository.AddAsync(rewards);
            
            await _unitOfWork.CompleteAsync();
            
            return await Task.FromResult(new RewardsResponse(rewards));

        }
        catch (Exception e)
        {
            return await Task.FromResult(new RewardsResponse($"An error ocurred while saving the reward: {e.Message}"));
        }
    }
}
