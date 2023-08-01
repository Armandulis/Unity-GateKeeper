public class TalentsManager
{
    private MaximumManaTalent maximumManaTalent;
    private ManaRegenTalent manaRegenTalent;

    public TalentsManager( HeroManager heroManager )
    {
        maximumManaTalent = new MaximumManaTalent(heroManager);
        manaRegenTalent = new ManaRegenTalent(heroManager);
    }

    public MaximumManaTalent GetMaximumManaTalent()
    {
        return maximumManaTalent;
    }


    public ManaRegenTalent GetManaRegenTalent()
    {
        return manaRegenTalent;
    }

    public TalentPoint[] GetManaTalentPoints()
    {
        return new TalentPoint[] {
            GetMaximumManaTalent(),
            GetManaRegenTalent()
        };
    }
}