using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Thiny/Player")]
public class PlayerThiny : ScriptableObject
{
    [Header ("Status")]
    public new string name;
    public Sprite character;
    public Color32 colorThiny;
    public Elemental elemental; 
    public float hp;
    public float def;
    public float atk;
    public float mp;
    public float atkSpeed;
    public float moveSpeed;
    public float criticalRate;
    public float criticalDamage;
    public float skillResistance;
    public bool isRange;
    [Header("In Game")]
    public float currentHp;
    public float currentMp;
    public List<float> timeSkills = new List<float>();
    public bool firstTime = true;
    public bool isDied = false;
    public bool cri = false;
    public GameObject thinyPrefab;
    [Header("In Inventory")]
    public bool isHaving = false;
    public List<Skill> skills = new List<Skill>();
    public void FirstShow()
    {
        //ตั้งค่าตัวแรกตอนเริ่มเกม
        currentHp = hp;
        currentMp = mp;
        firstTime = false;
    }
    public void SetUpThiny()
    {
        //ตั้งค่าตัวที่ 2,3 ตอนเริ่มเกม
        if (firstTime)
        {
            currentHp = hp;
            currentMp = mp;
            firstTime = false;
            timeSkills[0] = 99f;
            timeSkills[1] = 99f;
            timeSkills[2] = 99f;
            timeSkills[3] = 99f;
        }
        
    }

    // Update is called once per frame
    public float Critical(float damage)
    {
        cri = false;
        float critical = Random.Range(0f, 100f);
        if (critical <= criticalRate)
        {
            damage = damage*criticalDamage/ 100;
            cri = true;
        }
        return damage;
    }
    public Color32 showColor()
    {
        Color32 color;
        if(!(isDied)){
            color = colorThiny;
        }
        else
        {
            color = new Color32(0, 0, 0, 255);
        }
        return color;
    }
}
