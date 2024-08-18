using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        offset = new Vector3(0, 0, -10);
    }
    // Update is called once per frame
    private void Update()
    {
        
        if (player != null && !(GameController.instance.gameOver))
        {
            transform.position = new Vector3(
            player.transform.position.x + offset.x,
            player.transform.position.y + offset.y,
            offset.z);
            /* player = PlayerMovement.instance.transform;
             transform.position = new Vector3(
             player.transform.position.x + offset.x,
             player.transform.position.y + offset.y,
             offset.z
             );*/
        }
        else if(GameController.instance.gameOver)
        {
            player = GameObject.FindGameObjectWithTag("GameController").transform;
        }
        else if (player == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
            // player = PlayerMovement.instance.transf
       
}
