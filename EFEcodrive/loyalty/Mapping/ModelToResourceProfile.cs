using AutoMapper;
using EFEcodrive.loyalty.Domain.Models;
using EFEcodrive.loyalty.Resources;

namespace EFEcodrive.loyalty.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Rewards, RewardsResource>();
    }
}