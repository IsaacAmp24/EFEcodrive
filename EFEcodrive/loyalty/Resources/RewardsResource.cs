namespace EFEcodrive.loyalty.Resources;

public class RewardsResource
{
    public int Id { get; set; }
    /*public int fleetId { get; set; }*/
    public string RewardName { get; set; }
    public string description { get; set; } /* no required */
    public int score { get; set; }
}