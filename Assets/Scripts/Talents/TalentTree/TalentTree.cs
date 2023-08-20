using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentTree : MonoBehaviour
{
    public static TalentTree talentTree;

    private TalentsManager talentsManager;
    private HeroManager heroManager;
    private GameManager gameManager;
    private void Awake() => talentTree = this;

    public int[] talentLevels;
    public int[] talentCaps;
    public string[] talentTitles;
    public string[] talentDescriptions;


    public List<Talent> talentList;
    public GameObject manaTreeHolder; 
    public GameObject utilityTreeHolder; 

    public int availableTalentPoints;
    

    private void Start() {

        gameManager = GameManager.instance;
        heroManager = gameManager.heroManager;
        talentsManager = new TalentsManager( heroManager );
        availableTalentPoints = heroManager.GetHeroLevelSystemManager().GetLevel();

        OpenManaTree();
        UpdateAllTalentUI();
    }


    public void UpdateAllTalentUI()
    {
        foreach( var talent in talentList )
        {
            talent.UpdateUI();
        }
    }
    public void AddAvailableTalentPoint()
    {
        availableTalentPoints = availableTalentPoints + 1;
    }

    public void OpenManaTree()
    {
        ResetTalentTreeNodes();
        manaTreeHolder.SetActive( true);
        TalentPoint[] talentPoints = talentsManager.GetManaTalentPoints();
        foreach( var talent in manaTreeHolder.GetComponentsInChildren<Talent>())
        {
            talentList.Add(talent);
        }
        FillInTalentTree( talentPoints );
        UpdateAllTalentUI();
    }

    public void OpenUtilityTree()
    {
        ResetTalentTreeNodes();
        
        utilityTreeHolder.SetActive( true );
        TalentPoint[] talentPoints = talentsManager.GetUtilityTalentPoints();
        foreach( var talent in utilityTreeHolder.GetComponentsInChildren<Talent>())
        {
            talentList.Add(talent);
        }

        FillInTalentTree( talentPoints );
        UpdateAllTalentUI();
    }

    public void FillInTalentTree( TalentPoint[] talentPoints)
    {
        for (var i = 0; i < talentList.Count; i++)
        {
            talentList[i].SetTalentPoint( talentPoints[i] );
        } 
    }

    public void ResetTalentTreeNodes()
    {   
        manaTreeHolder.SetActive( false);
        utilityTreeHolder.SetActive( false );
        talentList.Clear();
    }
}
