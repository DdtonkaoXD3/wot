using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Immortal;
    public bool GodDamage;
    public bool infiniteMoney;
    public static GodMode instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (GodDamage)
        {
            PlayerManager.instance.damage = 999;
        }
        if(infiniteMoney){
            ResourceSystem.instance.coin = 999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
