using System;
using System.Collections;
using UnityEngine;

public class HeroManaManager
{
    public float currentMana = 500;
    public float maxMana = 500;
    public int manaRegen = 50;
    public int manaOnKill = 0;
    public int manaOnGettingDamaged = 0;
    public int manaOnEnemyHit = 0;
    public int manaOnNotMoving = 0;
    public bool? toggleManaNotMoving = null;
    public int manaOnMovingToFix = 0;

    public IEnumerator ManaRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log( "regen" + manaRegen);
            currentMana += manaRegen;
            if (currentMana + manaRegen > maxMana)
            {
                currentMana = maxMana;
            }
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

    public void AddMana( int manaAmount )
    {
        currentMana += manaAmount;
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
        Debug.Log("mana on enemy hit : " + manaOnEnemyHit);
        AddMana( manaOnEnemyHit );
    }
}