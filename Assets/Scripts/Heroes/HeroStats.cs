using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    // Movement
    public int currentmovementSpeed = 5;
    public int basicMovementSpeed = 5;
    public int maxSpeed = 20;

    // Health
    public float currentHealth = 100;
    public float maxHealth = 100;    

    // Basic Spells
    // Amount
    public int basicAttackAmountLevel = 1;
    public int basicAttackAmountLevelMax = 6;
    public int basicAttackAmountLevelLeveled = 1;

    // Amount Size
    public int basicAttackSizeLevel = 1;
    public int basicAttackSizeLevelMax = 6;
    public int basicAttackSizeLevelLeveled = 1;

    // Bounce rate
    public int basicAttackBounceLevel = 1;
    public int basicAttackBounceLevelMax = 6;
    public int basicAttackBounceLevelLeveled = 1;
    
    public int CalculateBasicAttackBouncePercentage()
    {
        if( basicAttackSizeLevelLeveled == 1 ) return 25;
        if( basicAttackSizeLevelLeveled == 2 ) return 50;
        if( basicAttackSizeLevelLeveled == 3 ) return 75;
        if( basicAttackSizeLevelLeveled == 4 ) return 100;
        if( basicAttackSizeLevelLeveled == 5 ) return 125;
        if( basicAttackSizeLevelLeveled == 6 ) return 200;
        return 0;
    }

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
