using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectThiny : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerThiny player;
    public static SelectThiny instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
