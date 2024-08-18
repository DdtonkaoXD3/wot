using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTeam : MonoBehaviour
{
    public Team team;
    public static SetTeam instance;
    // Start is called before the first frame update
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
