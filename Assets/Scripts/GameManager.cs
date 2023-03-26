using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public HeroController heroController;

    private void Awake()
    {
        if( instance == null )
        {
            instance = this;
            DontDestroyOnLoad( gameObject );
        }    
        else{
          Destroy(gameObject);
        }
    }

    
}
