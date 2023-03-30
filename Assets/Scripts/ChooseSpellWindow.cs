using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseSpellWindow : MonoBehaviour
{
    private HeroStats heroStats;
    public TextMeshProUGUI FirstSpellText;
    public TextMeshProUGUI SecondSpellText;
    public TextMeshProUGUI ThirdSpellText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.instance;
        heroStats = gameManager.heroStats;

        Time.timeScale = 0f;

        if( heroStats.basicAttackAmountLevelLeveled >= heroStats.basicAttackAmountLevelMax )
        {
            Destroy(FirstSpellText.gameObject);
        }
        else
        {
FirstSpellText.text = "Your basic attack will now launch" + (heroStats.basicAttackAmountLevelLeveled + 1) + "Bolts";
        
        }
            SecondSpellText.text = "Your basic attack will now increase in size by" + ((heroStats.basicAttackSizeLevelLeveled +1) * 100) + "%";
        ThirdSpellText.text = "Your basic attack will now bounce" + (heroStats.basicAttackBounceLevelLeveled + 1) * 25 + " percentage";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseFirstSpell()
    {   
        if( heroStats.basicAttackAmountLevelLeveled == heroStats.basicAttackAmountLevel ) heroStats.basicAttackAmountLevel++;
        heroStats.basicAttackAmountLevelLeveled++;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void ChooseSecondSpell()
    {
        
        if( heroStats.basicAttackSizeLevelLeveled == heroStats.basicAttackSizeLevel ) heroStats.basicAttackSizeLevel++;
        heroStats.basicAttackSizeLevelLeveled++;
        Time.timeScale = 1f;
         Destroy(gameObject);
    }
    
    public void ChooseThirdSpell()
    {
        if( heroStats.basicAttackBounceLevelLeveled == heroStats.basicAttackBounceLevel ) heroStats.basicAttackBounceLevel++;
         heroStats.basicAttackBounceLevelLeveled++;
         Time.timeScale = 1f;
         Destroy(gameObject);
    }
}
