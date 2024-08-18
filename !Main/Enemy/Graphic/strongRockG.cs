using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strongRockG : MonoBehaviour
{
    // Start is called before the first frame update
    float rotationStrong;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Dr.Flask") == null)
        {
            if(GameObject.FindWithTag("Player") != null)
            {
                if (GameObject.FindWithTag("Player").transform.position.x - transform.position.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);

                }
            }
            
        }
        else
        { 
            if (GameObject.Find("Dr.Flask") != null)
            {
                if (GameObject.Find("Dr.Flask").transform.position.x - transform.position.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);

                }
            }
        }
            
            
    }
}
