using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothnes;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {     
        if(!player) return;
        Vector3 newPosition = Vector3.Lerp( transform.position, player.position + offset, smoothnes );
        // Vector2 tempPos = new Vector2( player.position.x, player.position.y );
        transform.position = newPosition;
    }
}
