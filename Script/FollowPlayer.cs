using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;
    public static FollowPlayer instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    // Update is called once per frame
    private void Update()
    {

        if (player != null && !(GameController.instance.gameOver))
        {
            
             player = PlayerMovement.instance.transform;
             transform.position = new Vector3(
             player.transform.position.x,
             player.transform.position.y,
             0f
             );
        }
        else if (GameController.instance.gameOver)
        {
            player = GameObject.FindGameObjectWithTag("GameController").transform;
        }
        else if (player == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
