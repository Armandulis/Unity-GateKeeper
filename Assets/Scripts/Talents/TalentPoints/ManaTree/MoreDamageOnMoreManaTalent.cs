public class MoreDamageOnMoreManaTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "MoreDamageOnMoreMana";
    int currentLevel = 0;
    int maxLevel = 5;


    public MoreDamageOnMoreManaTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().moreDamageOnMoreManaLevel;
    }

    public int LevelUp()
    {

        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().moreDamageOnMoreManaLevel++;
        return currentLevel;
    }

    public string GetTitle()
    {
        return "More damage while with high mana";
    }

    public string GetDescription()
    {
        return "Increase your damage by 0.01 for every mana percentage not used" ;
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