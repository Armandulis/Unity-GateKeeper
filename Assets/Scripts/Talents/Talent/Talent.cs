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
    private bool canLearnTalent = true;

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
            talentTree.talentList[connectedTalentPoint].SetTalentPointCanLearn( talentPoint.GetCurrentLevel() == talentPoint.GetMaxLevel() );
        }

        test++;
        titleText.text = talentPoint.GetTitle();
        descriptionText.text = talentPoint.GetDescription();
        levelsText.text = talentPoint.GetCurrentLevel() + "/" + talentPoint.GetMaxLevel();
        FixBoarderStatus();
    }

    public void SetTalentPointCanLearn( bool canLearn )
    {
        canLearnTalent = canLearn;
    }

    public void FixBoarderStatus()
    {
        if( talentPoint.GetCurrentLevel() > 0 )
        {
          boarder.GetComponent<Image>().sprite = learnedTalentPointsImage;
            levelsText.color = Color.yellow;

            if( talentPoint.GetCurrentLevel() == talentPoint.GetMaxLevel() || talentTree.availableTalentPoints == 0 )
            {
            levelsText.color = Color.yellow;
                return;
            }
        }


        if( talentTree.availableTalentPoints > 0 && canLearnTalent == true )
        {
            levelsText.color = Color.green;
          boarder.GetComponent<Image>().sprite = availableTalentPointsImage;
            return;
        }

        if(  talentTree.availableTalentPoints == 0 || canLearnTalent == false )
        {
            
            levelsText.color = Color.gray;
            boarder.GetComponent<Image>().sprite = lockedTalentPointsImage;
            return;
        }

    }

    public void LearnTalent()
    {

        if(talentTree.availableTalentPoints < 1 || talentPoint.GetMaximumTalentPoints() <= talentPoint.GetCurrentTalentPoints() || !canLearnTalent ) return;
        talentTree.availableTalentPoints--;
        talentPoint.LevelUp();
        talentTree.UpdateAllTalentUI();
    }

    public void SetTalentPoint( TalentPoint talentPoint )
    {
        this.talentPoint = talentPoint;
    }
}
