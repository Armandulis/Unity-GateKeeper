public class TalentsManager
{
    private MaximumManaTalent maximumManaTalent;
    private ManaRegenTalent manaRegenTalent;
    private ManaOnKillTalent manaOnKillTalent;
    private MoreDamageOnMoreManaTalent moreDamageOnMoreManaTalent;
    private MoreDamageOnLessManaTalent moreDamageOnLessManaTalent;
    private ManaRegenWhenNotMovingTalent manaRegenWhenNotMovingTalent;

    public TalentsManager( HeroManager heroManager )
    {
        maximumManaTalent = new MaximumManaTalent(heroManager);
        manaRegenTalent = new ManaRegenTalent(heroManager);
        manaOnKillTalent = new ManaOnKillTalent(heroManager);
        moreDamageOnMoreManaTalent = new MoreDamageOnMoreManaTalent(heroManager);
        moreDamageOnLessManaTalent = new MoreDamageOnLessManaTalent(heroManager);
        manaRegenWhenNotMovingTalent = new ManaRegenWhenNotMovingTalent( heroManager );
    }

    public MaximumManaTalent GetMaximumManaTalent()
    {
        return maximumManaTalent;
    }


    public ManaRegenTalent GetManaRegenTalent()
    {
        return manaRegenTalent;
    }


    public ManaOnKillTalent GetManaOnKillTalent()
    {
        return manaOnKillTalent;
    }

    public MoreDamageOnMoreManaTalent GetMoreDamageOnMoreManaTalent()
    {
        return moreDamageOnMoreManaTalent;
    }

    
    public MoreDamageOnLessManaTalent GetMoreDamageOnLessManaTalent()
    {
        return moreDamageOnLessManaTalent;
    }
    
    public ManaRegenWhenNotMovingTalent GetManaRegenWhenNotMovingTalent()
    {
        return manaRegenWhenNotMovingTalent;
    }

    public TalentPoint[] GetManaTalentPoints()
    {
        return new TalentPoint[] {
            GetMaximumManaTalent(),
            GetManaRegenTalent(),
            GetManaOnKillTalent(),
            GetMoreDamageOnMoreManaTalent(),
            GetMoreDamageOnLessManaTalent(),
            GetManaRegenWhenNotMovingTalent()
    };
    }
}