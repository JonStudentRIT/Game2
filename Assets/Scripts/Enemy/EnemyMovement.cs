using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy enemy;
    void Start()
    {
        enemy = new Melee(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.player.t.position.y >= gameObject.transform.position.y)
        {
            if(Movement.player.t.position.x < gameObject.transform.position.x)
            {
                enemy.MoveLeft();
            }
            else
            {
                enemy.MoveRight();
            }
        }
    }
}
