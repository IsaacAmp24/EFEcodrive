namespace EFEcodrive.loyalty.Domain.Models;

public class Rewards
{
    public int Id { get; set; }
    public int fleetId { get; set; }
    public string RewardName { get; set; }
    public string description { get; set; } /* no required */
    public int score { get; set; }

}