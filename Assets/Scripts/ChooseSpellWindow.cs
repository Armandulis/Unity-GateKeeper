using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseSpellWindow : MonoBehaviour
{
    private HeroController heroController;
    public TextMeshProUGUI FirstSpellText;
    public TextMeshProUGUI SecondSpellText;
    public TextMeshProUGUI ThirdSpellText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        heroController = gameManager.heroController;

        Time.timeScale = 0f;
        FirstSpellText.text = "Your basic attack will now launch" + (heroController.basicAttackAmountLevelLeveled + 1) + "Bolts";
        SecondSpellText.text = "Your basic attack will now increase in size by" + ((heroController.basicAttackSizeLevelLeveled +1) * 100) + "%";
        ThirdSpellText.text = "Your basic attack will now bounce" + (heroController.basicAttackBounceLevelLeveled + 1) + "Bolts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseFirstSpell()
    {   
        if( heroController.basicAttackAmountLevelLeveled == heroController.basicAttackAmountLevel ) heroController.basicAttackAmountLevel++;
        heroController.basicAttackAmountLevelLeveled++;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void ChooseSecondSpell()
    {
        
        if( heroController.basicAttackSizeLevelLeveled == heroController.basicAttackSizeLevel ) heroController.basicAttackSizeLevel++;
        heroController.basicAttackSizeLevelLeveled++;
        Time.timeScale = 1f;
         Destroy(gameObject);
    }
    
    public void ChooseThirdSpell()
    {
        if( heroController.basicAttackBounceLevelLeveled == heroController.basicAttackBounceLevel ) heroController.basicAttackBounceLevel++;
         heroController.basicAttackBounceLevelLeveled++;
         Time.timeScale = 1f;
         Destroy(gameObject);
    }
}
