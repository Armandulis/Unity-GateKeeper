using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TalentTree;

public class HeroLevelSystemManager
{
    private int level = 1;
    private float experience = 0;
    private float experienceToNextLevel = 100;

    public HeroLevelSystemManager()
    {
        Debug.Log("LevelSystem");
        level = 1;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience( int experienceGained ) {
        experience += experienceGained;

        if( experience >= experienceToNextLevel )
        {
            level++;
            experience -= experienceToNextLevel;
            experienceToNextLevel *= 0.2f;

            talentTree.AddAvailableTalentPoint();
            talentTree.UpdateAllTalentUI();
        }
        Debug.Log( GetLevel() );
    }

    public int GetLevel()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / experienceToNextLevel;
    }
}
