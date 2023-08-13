public class MaximumManaTalent : TalentPoint
{
    private HeroManager heroManager;

    
    string id = "MaximumManaTalent";
    int currentLevel = 0;
    int maxLevel = 5;
    public int[] connectedTalentIds = { 3 };


    public MaximumManaTalent( HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().maximumManaLevel;
    }

    

    public int LevelUp()
    {

        if( currentLevel >= maxLevel ) return maxLevel;    
        currentLevel++;
        heroManager.GetHeroTalentsManager().maximumManaLevel++;
        heroManager.GetHeroManaManager().UpdateStatsForMaximumManaTalentLevel( currentLevel);
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Maximum mana";
    }

    public string GetDescription()
    {
        return "Increase your maximum mana by 100";
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