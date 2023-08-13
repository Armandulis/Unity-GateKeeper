public class ManaOnEnemyHitTalent : TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaOnEnemyHitTalent";
    int currentLevel = 0;
    int maxLevel = 5;

    public ManaOnEnemyHitTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaOnEnemyHitLevel;
    }
    public int GetCurrentTalentPoints()
    {
        return currentLevel;
    }

    public string GetDescription()
    {
        return "Gain " + currentLevel + 1 +" mana when you hit an enemy";
    }

    public int GetMaximumTalentPoints()
    {
        return maxLevel;
    }

    public string GetTitle()
    {
        return "Mana on hitting enemy";
    }

    public int LevelUp()
    {
        if(currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaOnEnemyHitLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForManaOnEnemyHitTalentLevel(currentLevel);
        return currentLevel;
    }
    
    public int[] GetConnectedTalentPoints()
    {
        return new int[] { 9 };
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