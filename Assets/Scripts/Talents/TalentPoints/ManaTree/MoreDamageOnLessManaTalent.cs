 public class MoreDamageOnLessManaTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "MoreDamageOnLessMana";
    int currentLevel = 0;
    int maxLevel = 5;


    public MoreDamageOnLessManaTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().moreDamageOnLessManaLevel;
    }

    public int LevelUp()
    {

        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().moreDamageOnLessManaLevel++;
        return currentLevel;
    }

    public string GetTitle()
    {
        return "More damage while with low on mana";
    }

    public string GetDescription()
    {
        return "Increase your damage by 0.01 for every mana percentage missing" ;
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