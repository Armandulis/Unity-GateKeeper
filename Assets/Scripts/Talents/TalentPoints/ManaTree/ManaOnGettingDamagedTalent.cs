public class ManaOnGettingDamagedTalent : TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaOnGettingDamagedTalent";
    int currentLevel = 0;
    int maxLevel = 5;

    public ManaOnGettingDamagedTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaOnGettingDamagedLevel;
    }
    public int GetCurrentTalentPoints()
    {
        return currentLevel;
    }

    public string GetDescription()
    {
        return "Gain " + currentLevel + 1 +" mana on getting damaged";
    }

    public int GetMaximumTalentPoints()
    {
        return maxLevel;
    }

    public string GetTitle()
    {
        return "Mana on losing health";
    }

    public int LevelUp()
    {
        if(currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaOnGettingDamagedLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaOnGettingDamagedTalentLevel(currentLevel);
        return currentLevel;
    }
    
    public int[] GetConnectedTalentPoints()
    {
        return new int[] { 8 };
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