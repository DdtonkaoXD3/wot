using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotBox2 : MonoBehaviour
{
    public Skill InfoSkill2;
    public static SkillSlotBox2 instance;
    [SerializeField] private Button slotSkill;
    [SerializeField] private Text textSkill;
    [SerializeField] private Image fadeCooldown;
    [SerializeField] private float timeSkill;
    [SerializeField] private Transform player;
    bool check;
    GameObject SkillToSpawn;
    MonoBehaviour skillObject { get; set; }
    GameObject newSkill { get; set; }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (InfoSkill2 != PlayerManager.instance.player.skills[1] && PlayerManager.instance.player.skills[1]!=null)
        {
            GameObject player = GameObject.Find("Player");
            InfoSkill2 = PlayerManager.instance.player.skills[1];
            SkillToSpawn = PlayerManager.instance.player.skills[1].prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            PlayerManager.instance.player.timeSkills[1] = InfoSkill2.cooldown;
            
            textSkill.text = InfoSkill2.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill2.elemental.elementalColor;
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
        if (InfoSkill2 != PlayerManager.instance.player.skills[1] &&PlayerManager.instance.player.skills[1] != null)
        {
            InfoSkill2 = PlayerManager.instance.player.skills[1];
            GameObject player = GameObject.Find("Player");
            textSkill.text = InfoSkill2.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill2.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;
            GameObject SkillToSpawn = InfoSkill2.prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            skillObject = newSkill.GetComponent<MonoBehaviour>();
            check = false;
        }else if(PlayerManager.instance.player.skills[1] == null)
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
            InfoSkill2 = null;
        }
        if (InfoSkill2 != null)
        {
            if (InfoSkill2.isCooldown)
            {
                PlayerManager.instance.player.timeSkills[1] += Time.deltaTime;
            }
            float radio = (InfoSkill2.cooldown - PlayerManager.instance.player.timeSkills[1]) / InfoSkill2.cooldown;
            radio = Mathf.Max(radio, 0);
            fadeCooldown.rectTransform.localScale = new Vector3(1, radio, 1);
            InfoSkill2.CooldownSkill(PlayerManager.instance.player.timeSkills[1]);

            if (ManaSystem.instance.MpPlayer >= InfoSkill2.CheckMana() &&(PlayerManager.instance.player.timeSkills[1] >= InfoSkill2.cooldown) && Input.GetKeyDown(KeyCode.E) && !InfoSkill2.isUsing)
            {
                (skillObject as ISkill).UseSkill();
                PlayerManager.instance.player.timeSkills[1] = InfoSkill2.InteractSkill();
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
