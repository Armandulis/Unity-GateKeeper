using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(fileName = "New HeroController", menuName = "HeroController" )]
public class HeroController : ScriptableObject
{
    // Movement
    public int currentmovementSpeed;
    public int basicMovementSpeed;
    public int maxSpeed;


    // Health
    public float currentHealth;
    public float maxHealth;
    

    // Basic Spells
    public int basicAttackAmountLevel;
    public int basicAttackAmountLevelMax;
    public int basicAttackAmountLevelLeveled;


    public int basicAttackSizeLevel;
    public int basicAttackSizeLevelMax;
    public int basicAttackSizeLevelLeveled;

    public int basicAttackBounceLevel;
    public int basicAttackBounceLevelMax;
    public int basicAttackBounceLevelLeveled;
    
    public int CalculateBasicAttackBouncePersentage()
    {
        if( basicAttackSizeLevelLeveled == 1 ) return 25;
        if( basicAttackSizeLevelLeveled == 2 ) return 50;
        if( basicAttackSizeLevelLeveled == 3 ) return 75;
        if( basicAttackSizeLevelLeveled == 4 ) return 100;
        if( basicAttackSizeLevelLeveled == 5 ) return 125;
        if( basicAttackSizeLevelLeveled == 6 ) return 200;
        return 0;
    }
}
