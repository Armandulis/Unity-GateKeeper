public class TalentsManager
{
    private MaximumManaTalent maximumManaTalent;
    private ManaRegenTalent manaRegenTalent;
    private ManaOnKillTalent manaOnKillTalent;
    private ManaOnEnemyHitTalent manaOnEnemyHitTalent;
    private ManaOnGettingDamagedTalent manaOnGettingDamagedTalent;
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
        manaOnGettingDamagedTalent = new ManaOnGettingDamagedTalent( heroManager );
        manaOnEnemyHitTalent = new ManaOnEnemyHitTalent( heroManager );
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
    public ManaOnGettingDamagedTalent GetManaOnGettingDamagedTalent()
    {
        return manaOnGettingDamagedTalent;
    }
        public ManaOnEnemyHitTalent GetManaOnEnemyHitTalent()
    {
        return manaOnEnemyHitTalent;
    }

    public TalentPoint[] GetManaTalentPoints()
    {
        return new TalentPoint[] {
            GetMaximumManaTalent(),
            GetManaRegenTalent(),
            GetManaOnKillTalent(),
            GetMoreDamageOnMoreManaTalent(),
            GetMoreDamageOnLessManaTalent(),
            GetManaRegenWhenNotMovingTalent(),
            GetManaOnGettingDamagedTalent(),
            GetManaOnEnemyHitTalent()
            
    };
    }
}