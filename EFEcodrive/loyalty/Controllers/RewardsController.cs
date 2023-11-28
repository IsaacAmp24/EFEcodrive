using AutoMapper;
using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Domain.Services;
using EFEcodrive.loyalty.Resources;
using EFEcodrive.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EFEcodrive.loyalty.Controllers;


[ApiController]
[Route("/api/v1/")]


public class RewardsController : ControllerBase
{
    private readonly IRewardsService _rewardsService;
    private readonly IMapper _mapper;

    public RewardsController(IRewardsService rewardsService, IMapper mapper)
    {
        _rewardsService = rewardsService;
        _mapper = mapper;
    }

    [HttpPost("fleets/{fleetId}/rewards")]
    public async Task<IActionResult> PostAsync([FromBody] SaveRewardsResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var rewards = _mapper.Map<SaveRewardsResource, Rewards>(resource);

        var result = await _rewardsService.SaveAsync(rewards);

        if (!result.Success)
            return BadRequest(result.Message);

        var rewardsResource = _mapper.Map<Rewards, RewardsResource>(result.Resource);

        return Ok(rewardsResource);
    }
    
    [HttpGet("scores/{score}/rewards")]
    public async Task<IEnumerable<RewardsResource>> GetAllAsync()
    {
        var rewards = await _rewardsService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Rewards>,
            IEnumerable<RewardsResource>>(rewards);
        return resources;
    }

}