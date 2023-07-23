using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLevelSystemManager
{
    private int level;
    private float experience;
    private float experienceToNextLevel;

    public HeroLevelSystemManager()
    {
        Debug.Log("LevelSystem");
        level = 0;
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
