using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector] public static Player player;
    private float f_playerJumpForce = 500.0f;
    private float f_playerMoveSpeed = 5.0f;
    private float f_floorTimer = 0;
    private float f_floorTimerMax = 0.5f;
    private bool b_floorChange = true;

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(gameObject);
        player.StopMoving();
        player.setSpeed(f_playerMoveSpeed);
        player.setJumpHeight(f_playerJumpForce);
        player.b_canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.b_movingLeft)
        {
            player.MoveLeft(); // manages movement internally
        }
        else if (!player.b_movingLeft)
        {
            player.MoveRight(); // manages movement internally
        }
        else
        {
            // for some reason the player shouldnt be moving possible use onboarding or cutscene?
            player.StopMoving();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump(); // manages can jump internally
            player.b_canJump = false;
        }

        f_floorTimer += Time.deltaTime;
        if(f_floorTimer >= f_floorTimerMax)
        {
            b_floorChange = true;
        }
    }
    private void OnCollisionEnter(Collision Other)
    {
        player.b_canJump = true;
        if(Other.gameObject.tag == "LeftWall" || Other.gameObject.tag == "RightWall")
        {
            player.b_movingLeft = !player.b_movingLeft;
        }
        else if(Other.gameObject.tag == "Platform" && b_floorChange)
        {
            if(gameObject.transform.position.y + (gameObject.transform.localScale.y/2) < Other.gameObject.transform.position.y)
            {
                float temp = gameObject.transform.localScale.y + Other.gameObject.transform.localScale.y;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + temp, gameObject.transform.position.z);
                b_floorChange = false;
                f_floorTimer = 0;
            }
        }
        else if(Other.gameObject.tag == "Enemy")
        {
            Destroy(Other.gameObject);
        }
    }
}
