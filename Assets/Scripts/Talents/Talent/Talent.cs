using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static TalentTree;

public class Talent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int id;
    public int test = 0;
    public TalentPoint talentPoint;

    public Sprite availableTalentPointsImage;
    public Sprite lockedTalentPointsImage;
    public Sprite learnedTalentPointsImage;
    

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text levelsText;

    public GameObject tooltip;
    public GameObject boarder;

    public int[] connectedTalents;

    // Start is called before the fi rst frame update
    void Start()
    {
        tooltip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // tooltip.trasform.position = Input.mousePosition;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive( false);
    }   

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true);
    }

    public void UpdateUI()
    {
        foreach(var connectedTalentPoint in talentPoint.GetConnectedTalentPoints() )
        {
            talentTree.talentList[ connectedTalentPoint ].gameObject.SetActive( test == 1 ); 
        }

        test++;
        titleText.text = talentPoint.GetTitle();
        descriptionText.text = talentPoint.GetDescription();
        levelsText.text = talentPoint.GetCurrentLevel() + "/" + talentPoint.GetMaxLevel();
        FixBoarderStatus();


        // GetComponent<Button>().text = talentTree.talentLevels[id] >= talentTree.talentCaps[id] ? Color.yellow : talentTree.talentPoints > 1 ? Color.green : Color.white;
    }

    public void FixBoarderStatus()
    {
        if( talentPoint.GetCurrentLevel() > 0 )
        {
          boarder.GetComponent<Image>().sprite = learnedTalentPointsImage;

            if( talentPoint.GetCurrentLevel() == talentPoint.GetMaxLevel() )
            {
                return;
            }
        }


        if( talentTree.availableTalentPoints > 0 )
        {
          boarder.GetComponent<Image>().sprite = availableTalentPointsImage;
        }
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
