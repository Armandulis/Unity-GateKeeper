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



        // talentLevels = new int[3];
        // talentCaps = new[] { 10, 2, 1 };

        // talentTitles = new[] { "Manage Regen", "Max Mana", "Refresh Mana" };
        // talentDescriptions = new[]
        // {
        //     "Increase your mana regen by 20",
        //     "Increase your maximum mana by 20",
        //     "Gain a skill Refresh your mana"
        // };


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
