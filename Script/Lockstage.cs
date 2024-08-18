using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockstage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameLock;
    void Start()
    {
        gameLock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceSystem.instance.chapter >= 11)
        {
            gameLock.SetActive(true);
        }
    }
}
