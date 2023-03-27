using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public HeroStats heroStats;

    private void Awake()
    {
        if( instance == null )
        {
            instance = this;
            heroStats = gameObject.GetComponent<HeroStats>();
            DontDestroyOnLoad( gameObject );
        }    
        else{
          Destroy(gameObject);
        }
    }

    
}
