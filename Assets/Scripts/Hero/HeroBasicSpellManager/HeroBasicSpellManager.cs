public class HeroBasicSpellManager
{
    private int manaCost = 10;

    // Amount
    private int amountLevel = 1;
    private int amountLevelMax = 6;
    private int amountLevelLeveled = 1;

    // Amount Size
    private int sizeLevel = 1;
    private int sizeLevelMax = 6;
    private int sizeLevelLeveled = 1;

    // Bounce rate
    private int bounceLevel = 1;
    private int bounceLevelMax = 6;
    private int bounceLevelLeveled = 1;

    public int CalculateBasicAttackBouncePercentage()
    {
        if (bounceLevelLeveled == 1) return 25;
        if (bounceLevelLeveled == 2) return 50;
        if (bounceLevelLeveled == 3) return 75;
        if (bounceLevelLeveled == 4) return 100;
        if (bounceLevelLeveled == 5) return 125;
        if (bounceLevelLeveled == 6) return 200;
        return 0;
    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public int GetAmountLevel()
    {
        return amountLevel;
    }

    public int GetSpellSize()
    {
        return sizeLevel;
    }
}