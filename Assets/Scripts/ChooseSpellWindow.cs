using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseSpellWindow : MonoBehaviour
{

    GameObject spellCaster;
    public TextMeshProUGUI FirstSpellText;
    public TextMeshProUGUI SecondSpellText;
    public TextMeshProUGUI ThirdSpellText;

    // Start is called before the first frame update
    void Start()
    {
          Time.timeScale = 0f;
        spellCaster = GameObject.FindGameObjectWithTag( "Player" );
        FirstSpellText.text = "Your basic attack will now launch" + (spellCaster.GetComponent<CastSpell>().spellLevel + 1) + "Bolts";
        SecondSpellText.text = "Your basic attack will now increase in size by" + ((spellCaster.GetComponent<CastSpell>().spellSize +1) * 100) + "%";
        // FirstSpellText.text = "Your basic attack will now launch" + (spellCaster.GetComponent<CastSpell>().spellLevel + 1) + "Bolts";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseFirstSpell()
    {
        spellCaster.GetComponent<CastSpell>().spellLevel++;
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void ChooseSecondSpell()
    {
        spellCaster.GetComponent<CastSpell>().spellSize++; 
        Time.timeScale = 1f;
         Destroy(gameObject);
    }
    
    public void ChooseThirdSpell()
    {
        spellCaster.GetComponent<CastSpell>().spellLevel++;
         Time.timeScale = 1f;
         Destroy(gameObject);
    }
}
