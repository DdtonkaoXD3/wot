using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    public PlayerThiny player,currentPlayer;
    public static PlayerManager instance;
    public float damage = 1f;
    public float Speed;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Speed = player.moveSpeed;
        damage = player.atk;
        currentPlayer = player;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerControl == null)
        {
            playerControl = GameObject.FindWithTag("Player");
        }
        transform.position = new(playerControl.transform.position.x, playerControl.transform.position.y, playerControl.transform.position.z);*/
        if (currentPlayer != player)
        {
            //เก่า
            currentPlayer.currentHp = HealthSystem.instance.HpPlayer;
            currentPlayer.currentMp = ManaSystem.instance.MpPlayer;

            //ใหม่

            
            player.SetUpThiny();
            Speed = player.moveSpeed;
            damage = player.atk;
    
            HealthSystem.instance.HpPlayer = player.currentHp;
            HealthSystem.instance.HpPlayerMax = player.hp;
            ManaSystem.instance.MpPlayer = player.currentMp;
            ManaSystem.instance.MpPlayerMax = player.mp;
            currentPlayer = player; 
        }
    }

}
