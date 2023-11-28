using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.Shared.Domain.Services.Communication;

namespace EFEcodrive.loyalty.Domain.Services.Communication;

public class RewardsResponse : BaseResponse<Rewards>
{
    public RewardsResponse(string message) : base(message)
    {
    }

    public RewardsResponse(Rewards resource) : base(resource)
    {
    }
}