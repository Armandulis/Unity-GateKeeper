public class ManaRegenWhenNotMovingTalent: TalentPoint
{
    private HeroManager heroManager;

    string id = "ManaRegenWhenNotMovingTalent";
    int currentLevel = 0;
    int maxLevel = 5;


    public ManaRegenWhenNotMovingTalent(HeroManager heroManager)
    {
        this.heroManager = heroManager;
        currentLevel = heroManager.GetHeroTalentsManager().manaRegenWhenNotMovingTalent;
    }

    public int LevelUp()
    {

        if (currentLevel >= maxLevel) return maxLevel;
        currentLevel++;
        heroManager.GetHeroTalentsManager().manaRegenWhenNotMovingTalent++;
        heroManager.GetHeroManaManager().UpdateStatsForManaWhenNotMovingTalentLevel(currentLevel);
        return currentLevel;
    }

    public string GetTitle()
    {
        return "Increase mana regen when you're standing still";
    }

    public string GetDescription()
    {
        return "Increase mana regen while not moving by " + currentLevel* 3 ;
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