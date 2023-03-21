using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag( "Player" ).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player) return;
        Vector2 tempPos = new Vector2( player.position.x, player.position.y );
        transform.position = tempPos;
    }
}
