using System;
using System.Collections;
using UnityEngine;

public class HeroManaManager
{
    public float currentMana = 500;
    public float maxMana = 500;
    public int manaRegen = 50;
    private int baseManaRegen = 50;
    public int manaOnKill = 0;
    public int manaOnNotMoving = 0;
    public bool toggleManaNotMoving = true;

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

        manaRegen = baseManaRegen + ( 50 * currentLevel );
    }

    internal void UpdateStatsForManaWhenNotMovingTalentLevel(int currentLevel)
    {

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
}