using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform g_track;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, g_track.position.y, gameObject.transform.position.z);
        if(g_track.position.y < 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.0f, gameObject.transform.position.z);
        }
        if(g_track.position.y > 89.5f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 89.5f, gameObject.transform.position.z);
        }
    }
}
