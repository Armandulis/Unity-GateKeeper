public class ManaRefreshCooldownTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaRefreshCooldownTalent";
    int currentLevel = 0;
    int maxLevel = 3;

    public ManaRefreshCooldownTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaRefreshCooldownLevel;
    }

    public int LevelUp()
    {
        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaRefreshCooldownLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaRefreshCooldownTalentLevel( 60 - ( currentLevel * 5 )  );
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Mana refresh cooldown";
    }

    public string GetDescription()
    {
        return "Reduce cooldown of your mana refresh ability" ;
    }


    public int GetMaximumTalentPoints()
    {
        return maxLevel;
    }
    public int GetCurrentTalentPoints()
    {
        return currentLevel;
    }
}