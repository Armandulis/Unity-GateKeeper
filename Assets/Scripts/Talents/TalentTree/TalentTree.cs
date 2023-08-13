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
    public GameObject talentHolder;

    public int availableTalentPoints;
    

    private void Start() {

        gameManager = GameManager.instance;
        heroManager = gameManager.heroManager;
        talentsManager = new TalentsManager( heroManager );
        availableTalentPoints = heroManager.GetHeroLevelSystemManager().GetLevel();

        TalentPoint[] talentPoints = talentsManager.GetManaTalentPoints();
        foreach( var talent in talentHolder.GetComponentsInChildren<Talent>())
        {
            talentList.Add(talent);
        }

        for (var i = 0; i < talentList.Count; i++)
        {
            talentList[i].SetTalentPoint( talentPoints[i] );
        } 
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



}
