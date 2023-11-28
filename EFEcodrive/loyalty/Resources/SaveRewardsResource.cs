using System.ComponentModel.DataAnnotations;

namespace EFEcodrive.loyalty.Resources;

public class SaveRewardsResource
{
    /*[Required]
    public int fleetId { get; set; }*/
    
    [Required]
    public string RewardName { get; set; }
    
    [Required]
    public string description { get; set; } /* no required */
    
    [Required]
    public int score { get; set; }
    
}