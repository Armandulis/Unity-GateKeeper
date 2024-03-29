public class ManaOnKillTalent : TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaOnKill";
    int currentLevel = 0;
    int maxLevel = 5;

    public ManaOnKillTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaOnKillLevel;
    }
    public int GetCurrentTalentPoints()
    {
        return currentLevel;
    }

    public string GetDescription()
    {
        return "Gain " + currentLevel + 1 +" mana on enemy kill";
    }

    public int GetMaximumTalentPoints()
    {
        return maxLevel;
    }

    public string GetTitle()
    {
        return "Mana on Kill";
    }

    public int LevelUp()
    {
        if(currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaOnKillLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaOnGettingDamagedTalentLevel(currentLevel);
        return currentLevel;
    }
    
    public int[] GetConnectedTalentPoints()
    {
        return new int[] { 5 };
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