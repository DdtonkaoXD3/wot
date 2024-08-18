using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    [SerializeField] private Skill skill;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UseSkill()
    {
        if (ManaSystem.instance.MpPlayer >= skill.PercentMana() && !skill.isUsing)
        {
            skill.InteractSkill();
            HealthSystem.instance.HpPlayer += 30;
        }
    }
}
