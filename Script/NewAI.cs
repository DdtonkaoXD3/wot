using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class NewAI : MonoBehaviour
{
    // Start is called before the first frame updat
    [SerializeField] AIDestinationSetter ai;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player")!= null)
        {
            ai.target = GameObject.FindWithTag("Player").transform;
        }
    }
}
