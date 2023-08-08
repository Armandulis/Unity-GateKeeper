using System;
using System.Collections;
using UnityEngine;

public class HeroManaManager
{
    public float currentMana = 500;
    public float maxMana = 500;
    public float manaRegen = 50;
    public float manaOnKill = 0;
    public float manaOnGettingDamaged = 0;
    public float manaOnEnemyHit = 0;
    public float manaOnNotMoving = 0;
    public bool? toggleManaNotMoving = null;
    public float manaOnMovingToFix = 0;
    private float manaShieldAmount = 0;
    private bool isManaShieldToggled = false;
    private float refreshManaAmount = 0;
    private bool canUseRefreshManaTalent = false;
    private float manaRefreshTalentCooldown = 999;

    public IEnumerator ManaRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            AddMana(manaRegen);
        }
    }

    public void ToggleNotMovingManaRegen( bool isMoving )
    {
        if( toggleManaNotMoving == isMoving )
        {
            return;
        }

        // Pretend that we are not moving, because if we chose talent while moving, me might run into bugs
        if( toggleManaNotMoving == null)
        {

            if( manaOnMovingToFix > 1 && !isMoving )
            {
                
                manaRegen -= manaOnMovingToFix;
                manaRegen += manaOnNotMoving;
            }
             manaOnMovingToFix = 0;
            toggleManaNotMoving = isMoving;
            return;
        } 
        
        toggleManaNotMoving = isMoving;
        if( isMoving )
        {
            manaRegen -= manaOnNotMoving;
            
            return;
        }
        
        manaRegen += manaOnNotMoving;
    }

    public bool IsEnoughMana( float manaNeeded )
    {
        return currentMana >= manaNeeded;
    }
    public float UseMana(float usedMana)
    {
        currentMana -= usedMana;
        return currentMana;
    }

    public float GetCurrentMana()
    {
        return currentMana;
    }

    public float GetMaxMana()
    {
        return maxMana;
    }

    public float GetManaPercentage()
    {
        return currentMana / maxMana;
    }

    internal void UpdateStatsForMaximumManaTalentLevel(int currentLevel)
    {
        maxMana = maxMana + currentLevel * 100;
    }
    
    internal void UpdateStatsForManaRegenTalentLevel(int currentLevel)
    {

        manaRegen += 50;
    }

    internal void UpdateStatsForManaWhenNotMovingTalentLevel(int currentLevel)
    {
        toggleManaNotMoving = null;
        manaOnMovingToFix = 3 * (currentLevel - 1);
        manaOnNotMoving = ( 3 * currentLevel );
    }

    
    internal void UpdateStatsForManaOnKillTalentLevel(int currentLevel)
    {
        manaOnKill = currentLevel;
    }

    public void AddMana( float manaAmount )
    {
        currentMana += manaAmount;
        if (currentMana + manaAmount > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public void AddManaOnKill()
    {
        AddMana( manaOnKill );
    }

    public float IncreaseDamageForCurrentMana(float baseHeroSpellDamage, float perNotMissingManaLevel = 0, float increasePerMissingManaLevel = 0)
    {
        float currentManaPercentage = currentMana / maxMana * 100;
        float notMissingManaBonus = ((baseHeroSpellDamage / 100) * currentManaPercentage) * perNotMissingManaLevel * 0.1f;
        float missingManaBonus = (((baseHeroSpellDamage / 100) * ( 100-currentManaPercentage))) * increasePerMissingManaLevel * 0.1f;
        return baseHeroSpellDamage + notMissingManaBonus + missingManaBonus;
    }

    internal void UpdateStatsForManaOnGettingDamagedTalentLevel(int currentLevel)
    {
        manaOnGettingDamaged = currentLevel; 
    }
    public void AddManaOnGettingDamaged()
    {
        AddMana( manaOnGettingDamaged );
    }

    internal void UpdateStatsForManaOnEnemyHitTalentLevel(int currentLevel)
    {
        
        manaOnEnemyHit = currentLevel;
    }

    public void AddManaOnEnemyHit()
    {
        AddMana( manaOnEnemyHit );
    }

    public float CheckManaForHealthModifiers( float damage )
    {
        if( manaShieldAmount == 0 || !isManaShieldToggled )
        {
            return damage;
        }

        float shieldedAmount = damage * manaShieldAmount;
        if( currentMana >= shieldedAmount )
        {
            UseMana(shieldedAmount);
            return damage - shieldedAmount;
        }
        
        // Disable mana shield because we don't have mana for it
        ToggleManaShield(false);
        return damage;
    }

    internal void UpdateStatsForManaShieldTalentLevel(float currentLevel)
    {
        manaShieldAmount = currentLevel;
    }

    internal bool IsManaShieldLearned()
    {
        return manaShieldAmount > 0;
    }
    public void ToggleManaShield( bool isToggled )
    {
        isManaShieldToggled = isToggled;
    }

    internal void UpdateStatsForManaRefreshTalentLevel(float manaAmount, float cooldownInSeconds)
    {
        canUseRefreshManaTalent = true;
        if( manaRefreshTalentCooldown > cooldownInSeconds )
        {
            manaRefreshTalentCooldown = cooldownInSeconds;
        }
        refreshManaAmount = manaAmount;
    }
    public bool CanUseRefreshManaTalent()
    {
        return canUseRefreshManaTalent;
    } 

    public IEnumerator UseRefreshManaTalent()
    {
        canUseRefreshManaTalent = false;
        
        AddMana( maxMana * refreshManaAmount );

        yield return new WaitForSeconds( manaRefreshTalentCooldown );
        canUseRefreshManaTalent = true;
    }

    internal bool IsRefreshManaTalentLearned()
    {
        return refreshManaAmount > 0;
    }

    internal void UpdateStatsForManaRefreshCooldownTalentLevel(float manaRefreshCD)
    {
        canUseRefreshManaTalent = true;
        manaRefreshTalentCooldown = manaRefreshCD;
    }
}