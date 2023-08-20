public class DashTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "DashTalent";
    int currentLevel = 0;
    int maxLevel = 1;


    public DashTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().dashLevel;
    }

    public int LevelUp()
    {
        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().dashLevel++;
        heroManager.GetHeroMovementManager().UpdateStatsForDashTalentLevel( currentLevel );
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Dash";
    }

    public string GetDescription()
    {
        return "Learn to dash a small distance" ;
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