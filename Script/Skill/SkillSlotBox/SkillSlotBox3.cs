using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotBox3 : MonoBehaviour
{
    public Skill InfoSkill3;
    public static SkillSlotBox3 instance;
    [SerializeField] private Button slotSkill;
    [SerializeField] private Text textSkill;
    [SerializeField] private Image fadeCooldown;
    [SerializeField] private float timeSkill;
    [SerializeField] private Transform player;
    MonoBehaviour skillObject { get; set; }
    GameObject newSkill { get; set; }
    bool check;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (InfoSkill3 != PlayerManager.instance.player.skills[2])
        {
            InfoSkill3 = PlayerManager.instance.player.skills[2];
            GameObject player = GameObject.Find("Player");
            GameObject SkillToSpawn = PlayerManager.instance.player.skills[2].prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            PlayerManager.instance.player.timeSkills[2] = InfoSkill3.cooldown;
            
            textSkill.text = InfoSkill3.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill3.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;

            
            skillObject = newSkill.GetComponent<MonoBehaviour>();
        }
        else
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
        }

    }
    private void Update()
    {
        if (InfoSkill3 != PlayerManager.instance.player.skills[2] && PlayerManager.instance.player.skills[2] != null)
        {
            InfoSkill3 = PlayerManager.instance.player.skills[2];
            GameObject player = GameObject.Find("Player");
            textSkill.text = InfoSkill3.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill3.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;

            GameObject SkillToSpawn = InfoSkill3.prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            skillObject = newSkill.GetComponent<MonoBehaviour>();
        }
        else if(PlayerManager.instance.player.skills[2] == null)
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
            InfoSkill3 = null;
        }
        if (InfoSkill3 != null)
        {
            if (InfoSkill3.isCooldown)
            {
                PlayerManager.instance.player.timeSkills[2] += Time.deltaTime;
            }
            float radio = (InfoSkill3.cooldown - PlayerManager.instance.player.timeSkills[2]) / InfoSkill3.cooldown;
            radio = Mathf.Max(radio, 0);
            fadeCooldown.rectTransform.localScale = new Vector3(1, radio, 1);
            InfoSkill3.CooldownSkill(PlayerManager.instance.player.timeSkills[2]);
            if (ManaSystem.instance.MpPlayer >= InfoSkill3.CheckMana() && (PlayerManager.instance.player.timeSkills[2] >= InfoSkill3.cooldown) && Input.GetKeyDown(KeyCode.R) && !InfoSkill3.isUsing)
            {
                (skillObject as ISkill).UseSkill();
                PlayerManager.instance.player.timeSkills[2] = InfoSkill3.InteractSkill();
                /*ManaSystem.instance.UseMana(InfoSkill.manaCost);
                InfoSkill.isUsing = true;*/
            }
     
        }
        
        
    }
    public void OnClickSkill()
    {
        (skillObject as ISkill).UseSkill();
    }
}
