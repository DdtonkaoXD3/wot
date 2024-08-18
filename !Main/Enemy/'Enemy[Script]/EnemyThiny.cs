using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Thiny/Enemy")]
public class EnemyThiny : ScriptableObject
{
    public new string name;
    public Sprite character;
    public Elemental elemental;
    public float hp;
    public float def;
    public float mp;
    public float atk;
    public float atkSpeed;
    public float moveSpeed;
    public float criticalRate;
    public float criticalDamage;
    public float skillResistance;
    public float spdBullet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
