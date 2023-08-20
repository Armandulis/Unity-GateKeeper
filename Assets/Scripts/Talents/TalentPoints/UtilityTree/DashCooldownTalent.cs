public class DashCooldownTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "DashCooldownTalent";
    int currentLevel = 0;
    int maxLevel = 4;


    public DashCooldownTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().dashCooldownLevel;
    }

    public int LevelUp()
    {
        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().dashCooldownLevel++;
        heroManager.GetHeroMovementManager().UpdateStatsForDashCooldownTalentLevel( 5 - currentLevel );
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Dash cooldown";
    }

    public string GetDescription()
    {
        return "Reduce dash cooldown by 1 second" ;
    }


    public int GetMaximumTalentPoints()
    {
        return maxLevel;
    }
    public int GetCurrentTalentPoints()
    {
        return currentLevel;
    }
    
    public int[] GetConnectedTalentPoints()
    {
        return new int[] {};
    }
    
    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public int GetCurrentLevel()
    {

        return currentLevel;
    }
}