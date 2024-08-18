using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SkillInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private int activeSlotIndexNum = 0;
    public int indexSkill;
    private PlayerControls playerControls;
    [SerializeField] private bool process;
    public static SkillInventory instance;
    Skill skill;
    [SerializeField]  private float timing;
    [SerializeField] float[] allCooldown = new float[] { 0f, 0f, 0f, 0f };
    private void Awake()
    {
        instance = this;
        //PlayerControls playerControls = new PlayerControls();
    }
    /*private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }*/
    private void Start()
    {
        //playerControls.InventorySkill.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());       

    }
    /*private void OnEnable()
    {
        playerControls.Enable();
    }*/
    private void Update()
    {
        SkillSlotBox[] skillSlotBoxs = GetComponentsInChildren<SkillSlotBox>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skill(1, skillSlotBoxs);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Skill(2, skillSlotBoxs);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Skill(3, skillSlotBoxs);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Skill(4, skillSlotBoxs);
        }
        else
        {

        }
        /*playerControls.InventorySkill.skill1.performed += context => indexSkill = context.ReadValue<int>() - 1;
        
        for (int i = 0; i < skillSlotBoxs.Length ; i++)
        {
            skill = skillSlotBoxs[i].GetSkillInfo();
            if (indexSkill == i)
            {
                MonoBehaviour skillObject = GameObject.Find(skill.name).GetComponent<MonoBehaviour>();
                (skillObject as ISkill).UseSkill();
                
            }
                

        }*/
    }
    private void FixedUpdate()
    {
        SkillSlotBox[] skillSlotBoxs = GetComponentsInChildren<SkillSlotBox>();
        //timing += Time.deltaTime;
        for (int i = 0; i > 3; i++)
        {
            skill = skillSlotBoxs[i].GetSkillInfo();
            allCooldown[i] += Time.deltaTime;
            if (allCooldown[i] >= skill.cooldown)
            {
                skill.isUsing = false;
                //allCooldown[i] = 0f;
            }
        }
    }


    private void Skill(int indexSkill, SkillSlotBox[] allSkill)
    {
        skill = allSkill[indexSkill - 1].GetSkillInfo();
        MonoBehaviour skillObject = skill.prefabSkill.GetComponent<MonoBehaviour>();

        if (!skill.isUsing && ManaSystem.instance.MpPlayer >= skill.manaCost)
        {
            (skillObject as ISkill).UseSkill();
        }

    }
}
