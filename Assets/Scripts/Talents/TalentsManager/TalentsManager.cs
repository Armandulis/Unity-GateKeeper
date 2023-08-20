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
    private ManaShieldTalent manaShieldTalent;
    private ManaRefreshTalent manaRefreshTalent;
    private ManaRefreshCooldownTalent manaRefreshCooldownTalent;

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
        manaShieldTalent = new ManaShieldTalent(heroManager);
        manaRefreshTalent = new ManaRefreshTalent( heroManager );
        manaRefreshCooldownTalent = new ManaRefreshCooldownTalent(heroManager);
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

    public ManaShieldTalent GetManaShieldTalent()
    {
        return manaShieldTalent;
    }

    public ManaRefreshTalent GetManaRefreshTalent()
    {
        return manaRefreshTalent;
    }

    public ManaRefreshCooldownTalent GetManaRefreshCooldownTalent()
    {
        return manaRefreshCooldownTalent;
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
            GetManaOnEnemyHitTalent(),
            GetManaShieldTalent(),
            GetManaRefreshTalent(),
            GetManaRefreshCooldownTalent()
        };
    }

    public TalentPoint[] GetUtilityTalentPoints()
    {
        return new TalentPoint[] {
            GetMaximumManaTalent()
        };
    }
}