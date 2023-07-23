using System.Collections;
using UnityEngine;

public class HeroManaManager
{
    public float currentMana = 500;
    public float maxMana = 500;
    public int manaRegen = 50;

    public IEnumerator ManaRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
  
            currentMana += manaRegen;
            if (currentMana + manaRegen > maxMana)
            {
                currentMana = maxMana;
            }
        }
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
}