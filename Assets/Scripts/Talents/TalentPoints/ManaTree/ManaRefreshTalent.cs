public class ManaRefreshTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaRefreshTalent";
    int currentLevel = 0;
    int maxLevel = 5;


    public ManaRefreshTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaRefreshLevel;
    }

    public int LevelUp()
    {
        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaRefreshLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaRefreshTalentLevel( currentLevel * 0.25f, 60 );
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Mana refresh";
    }

    public string GetDescription()
    {
        return "Refresh " + (((currentLevel + 1) * 0.25f ) * 100)+  "% of your mana" ;
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
        return new int[] { };
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