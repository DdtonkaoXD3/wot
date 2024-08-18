using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Interact/Skill")]
public class Skill : ScriptableObject
{
    public new string name;
    public bool percentDamage;
    public float damage;
    public bool PercentCost;
    public float manaCost;
    public float cooldown;
    public Elemental elemental;
    public Sprite artwork;
    public GameObject prefabSkill;
    public string description;
    public bool isUsing = false;
    public bool isCooldown = true;
    public Color32 colorElement;
    public float timeSkill = 0f;
    public float skillDamage;
    public bool canUse;
    [Header("In Inventory")]
    public bool isHaving = false;
    /*public Color32 ElementAnalysis()
    {
        switch (element)
        {
            case "clay":
                Color32 color = new Color32(173, 173, 173, 200);
                Debug.Log("Clay");
                break;
            case "lightning":
                Debug.Log("Lightning");
                Color32 color = new Color32(173, 173, 173, 200);
                break;

            case "rock":
                Debug.Log("Rock");
                Color32 color = new Color32(173, 173, 173, 200);
                break;
        }
        return color;
    }*/
    private void Awake()
    {
        
    }
    public Color32 ColorElement()
    {
        if (elemental.name.Equals("clay"))
        {
            colorElement = new Color32(173, 216, 230, 255);
        }
        else if (elemental.name.Equals("lightning"))
            colorElement = new Color32(255, 245, 166, 255);
        else if (elemental.name.Equals("rock"))
            colorElement = new Color32(194, 197, 204, 255);
        else
        {
            colorElement = new Color32(255, 255, 255, 255);
        }
        return colorElement;
    }
    public void CooldownSkill(float timeCycle)
    {
        if (timeCycle >= cooldown)
        {
            isUsing = false;
            
        }
    }
    public float CheckMana()
    {
        float checkMp;
        if (PercentCost)
        {
            checkMp = PercentMana();
        }
        else
        {
            checkMp = manaCost;
        }
        return checkMp;
    }
    public float InteractSkill()
    {
        if (PercentCost)
        {
            ManaSystem.instance.UseMana(PercentMana());
        }
        else
        {
            ManaSystem.instance.UseMana(manaCost);
        }
        
        isUsing = true;
        return 0;
    }
    public float PercentMana()
    {
        return PlayerManager.instance.player.mp * manaCost / 100;
    }
    public float PercentDamage()
    {
        return PlayerManager.instance.player.atk * damage / 100;
    }
    public float SkillDamage()
    {
        float skillDamage;
        if (percentDamage)
        {
            skillDamage = PercentDamage();
        }
        else
        {
            skillDamage = damage;
        }
            

        return skillDamage;
    }
    
}
