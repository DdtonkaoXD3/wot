using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotBox : MonoBehaviour
{
    [SerializeField] private Skill InfoSkill;
    public static SkillSlotBox instance;
    [SerializeField] private Button slotSkill;
    [SerializeField] private Text textSkill;
    [SerializeField] private Image fadeCooldown;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        textSkill.text = InfoSkill.name;
        GetComponent<Image>().color = Color.red;
    }
    public Skill GetSkillInfo()
    {
        return InfoSkill;
    }
    
}
