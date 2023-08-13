public class ManaShieldTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaShieldTalent";
    int currentLevel = 0;
    int maxLevel = 4;


    public ManaShieldTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaShieldLevel;
    }

    public int LevelUp()
    {
        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaShieldLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaShieldTalentLevel( currentLevel * 0.25f );
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Mana shield";
    }

    public string GetDescription()
    {
        return "Toggle mana shield to lose mana instead of " + ((currentLevel + 1) * 0.25f )+  " health when you get damaged" ;
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
        return new int[] { 3 };
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