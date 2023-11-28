using AutoMapper;
using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Resources;

namespace EFEcodrive.loyalty.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveRewardsResource, Rewards>();
    }
}