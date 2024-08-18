using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Skill skill;
    [SerializeField] private Button slotSkill;
    [SerializeField] private Text textSkill;
    [SerializeField] private Image fadeCooldown;
    public static SkillSlot instance;
    public float timing;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        textSkill.text = skill.name;
        GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1) && !skill.isUsing)
        {
        }
        
    }
}
