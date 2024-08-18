using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterThinty : ClassPlayer
{
    [SerializeField] private PlayerThiny thiny;
    void Start()
    {
        
        SetBullet(thiny);
    }

    // Update is called once per frame
    void Update()
    {
        TypeAttack(thiny, true);
    }
}
