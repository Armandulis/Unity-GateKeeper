public class ManaRegenTalent : TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaRegenTalent";
    int currentLevel = 0;
    int maxLevel = 5;


    public ManaRegenTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaRegenLevel;
    }



    public int LevelUp()
    {

        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaRegenLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaRegenTalentLevel(currentLevel);
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Mana regen";
    }

    public string GetDescription()
    {
        return "Increase your mana regen by 50";
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