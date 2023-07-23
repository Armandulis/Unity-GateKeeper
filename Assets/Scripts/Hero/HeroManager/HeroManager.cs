using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    private HeroHealthManager heroHealthManager;
    private HeroManaManager heroManaManager;
    private HeroMovementManager heroMovementManager;
    private HeroLevelSystemManager heroLevelSystemManager;
    private HeroBasicSpellManager heroBasicSpellManager;


    void Start()
    {
        StartCoroutine(heroHealthManager.HealthRegen());   
        StartCoroutine(heroManaManager.ManaRegen()); 
    }

    public HeroHealthManager GetHeroHealthManager()
    {
        return heroHealthManager;
    }

    public HeroLevelSystemManager GetHeroLevelSystemManager()
    {
        return heroLevelSystemManager;
    }

    public HeroManaManager GetHeroManaManager()
    {
        return heroManaManager;
    }

    
    public HeroMovementManager GetHeroMovementManager()
    {
        return heroMovementManager;
    }
    public HeroBasicSpellManager GetHeroBasicSpellManager()
    {
        return heroBasicSpellManager;
    }

}