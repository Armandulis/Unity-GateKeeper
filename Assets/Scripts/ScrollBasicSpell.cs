using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBasicSpell : MonoBehaviour
{
    public GameObject chooseSpellWindowObject;

    CastSpell spellCaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                    if( spellCaster && Input.GetKeyDown( KeyCode.F ) )
            {
            GameObject CanvasObject = GameObject.FindWithTag( "UICanvas" );
            Instantiate(chooseSpellWindowObject, CanvasObject.transform);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag( "Player" ) )
        {

            spellCaster = other.GetComponent<CastSpell>();
        }
    }
}
