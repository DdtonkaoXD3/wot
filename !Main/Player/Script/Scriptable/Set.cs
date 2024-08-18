using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TeamData.instance.SaveTeamToJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
