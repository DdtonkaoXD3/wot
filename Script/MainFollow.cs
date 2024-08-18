using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Start()
    {


    }
    private void Update()
    {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
    }
}
