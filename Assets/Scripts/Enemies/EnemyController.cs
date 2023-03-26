using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ CreateAssetMenu(fileName = "New EnemyController", menuName = "EnemyController" )]
public class EnemyController : ScriptableObject
{
    public float maxHealth;
    public float currentHelth;
    public Sprite sprite;
    public float speed;

    public Vector2 colliderSize;
    public Vector2 colliderOffset;

    public void SelfSetupObject( GameObject myObject )
    {
        myObject.GetComponent<SpriteRenderer>().sprite = sprite;
        myObject.GetComponent<CapsuleCollider2D>().size = colliderSize;
        myObject.GetComponent<CapsuleCollider2D>().offset = colliderOffset;
    }
}
