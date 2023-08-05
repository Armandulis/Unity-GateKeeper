using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TalentTree;

public class Talent : MonoBehaviour
{

    public int id;
    public TalentPoint talentPoint;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public int[] connectedTalents;

    // Start is called before the fi rst frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateUI()
    {
        titleText.text = talentPoint.GetTitle();
        descriptionText.text = talentPoint.GetDescription();

        // GetComponent<Button>().text = talentTree.talentLevels[id] >= talentTree.talentCaps[id] ? Color.yellow : talentTree.talentPoints > 1 ? Color.green : Color.white;
    }

    public void LearnTalent()
    {

        if(talentTree.availableTalentPoints < 1 || talentPoint.GetMaximumTalentPoints() <= talentPoint.GetCurrentTalentPoints() ) return;
        talentTree.availableTalentPoints--;
        talentPoint.LevelUp();
        talentTree.UpdateAllTalentUI();
    }

    public void SetTalentPoint( TalentPoint talentPoint )
    {
        this.talentPoint = talentPoint;
    }
}
