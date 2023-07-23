using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public HeroManager heroManager;

    
    private void Awake()
    {
        
        if( instance == null )
        {
            instance = this;
            heroManager = gameObject.GetComponent<HeroManager>();
            DontDestroyOnLoad( gameObject );
        }    
        else{
          Destroy(gameObject);
        }
    }    
}
