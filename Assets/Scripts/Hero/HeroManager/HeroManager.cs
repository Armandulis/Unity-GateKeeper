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
    private HeroTalentsManager heroTalentsManager;

    private void Awake()
    {
        heroLevelSystemManager = new HeroLevelSystemManager();
        heroTalentsManager = new HeroTalentsManager();
        heroHealthManager = new HeroHealthManager( );
        heroManaManager = new HeroManaManager();
        heroMovementManager = new HeroMovementManager();
        heroBasicSpellManager = new HeroBasicSpellManager();
    }    

    void Start()
    {
        StartCoroutine(heroHealthManager.HealthRegen());   
        StartCoroutine(heroManaManager.ManaRegen()); 
    }

    public HeroTalentsManager GetHeroTalentsManager()
    {
        return heroTalentsManager;
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