using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Team", menuName = "Team")]
public class Team : ScriptableObject
{
    // Start is called before the first frame update
    public new string name;
    public List<PlayerThiny> thinyTeam =  new List<PlayerThiny>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
