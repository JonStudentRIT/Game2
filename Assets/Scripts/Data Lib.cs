using UnityEngine;
namespace Data
{
    // basic element definition
    public class Index
    {
        protected int i_index = 0;
        protected string s_name = "Not Identifyed";
        protected string s_description = "Not Described";
        protected GameObject g = null;
        protected Rigidbody rig = null;
        public Transform t = null;
        protected Sprite s = null;
    }
    // all items in the game environment and interaction elements
    class Item : Index
    {
        // anything in thew world that is breakable or a set piece and should have interaction or collision
    }
    public class Characters : Index
    {
        protected int i_health = 100;
        protected int i_healthMax = 100;
        protected int i_healthMin = 0;
        protected bool b_alive = true;
        protected float f_moveSpeed = 0.0f;
        protected float f_jumpHeight = 0.0f;
        public bool b_canJump = true;
        // reduce the health of a character and automatically kill if the health is below the min
        public void HealthDown(int i_amount)
        {
            if(b_alive)
            {
                if((i_health - i_amount) > i_healthMin)
                {
                    i_health -= i_amount;
                }
                else
                {
                    i_health = 0;
                    b_alive = false;
                }
            }
        }
        // add health to a character that is capped at max
        public void HealthUp(int i_amount)
        {
            if (b_alive)
            {
                if ((i_health + i_amount) > i_healthMax)
                {
                    i_health += i_amount;
                }
                else
                {
                    i_health = i_healthMax;
                }
            }
        }
        // kill or revive character
        public void setAliveState(bool b_state)
        {
            b_alive = b_state;
        }
        // RigidBody Movement
        public void MoveLeft()
        {
            if(g)
            {
                if(rig)
                {
                    rig.drag = 0;
                    rig.angularDrag = 0;
                    rig.AddForce(-1 * t.right * f_moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
                }
                else
                {
                    Debug.Log("No RigidBody Found");
                }
            }
            else
            {
                Debug.Log("No Gameobject Found");
            }
        }
        public void MoveRight()
        {
            if (g)
            {
                if (rig)
                {
                    rig.drag = 0;
                    rig.angularDrag = 0;
                    rig.AddForce(t.right * f_moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
                }
                else
                {
                    Debug.Log("No RigidBody Found");
                }
            }
            else
            {
                Debug.Log("No Gameobject Found");
            }
        }
        public void StopMoving()
        {
            rig.drag = 100 * rig.mass;
            rig.angularDrag = 100 * rig.mass;
            rig.velocity = Vector3.zero;
            rig.angularVelocity = Vector3.zero;
        }
        public void Jump()
        {
            if (g)
            {
                if (rig)
                {
                    if(b_canJump)
                    {
                        rig.AddForce(t.up * f_jumpHeight * Time.deltaTime, ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.Log("No RigidBody Found");
                }
            }
            else
            {
                Debug.Log("No Gameobject Found");
            }
        }
    }
    public class Player : Characters
    {
        public bool b_movingLeft = false;
        public Player(GameObject gIn)
        {
            g = gIn;
            rig = g.GetComponent<Rigidbody>();
            t = g.GetComponent<Transform>();
            i_index = 1;
            s_name = "Player";
            s_description = "Player";
        }
        public void setSpeed(float fIn)
        {
            f_moveSpeed = fIn;
        }
        public void setJumpHeight(float fIn)
        {
            f_jumpHeight = fIn;
        }
    }
    class Enemy : Characters
    {

    }
    class Melee : Enemy
    {
        public Melee(GameObject gIn)
        {
            g = gIn;
            rig = g.GetComponent<Rigidbody>();
            t = g.GetComponent<Transform>();
            f_moveSpeed = 2.0f;
            i_index = 2;
            s_name = "Melee";
            s_description = "Short range Enemy";
        }
    }
    class Ranged : Enemy
    {
        public Ranged()
        {
            i_index = 3;
            s_name = "Ranged";
            s_description = "Long range Enemy";
        }
    }
    class Boss : Enemy
    {
        public Boss()
        {
            i_index = 4;
            s_name = "Boss";
            s_description = "Boss";
        }
    }
}