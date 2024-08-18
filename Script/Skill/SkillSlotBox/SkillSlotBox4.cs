using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlotBox4 : MonoBehaviour
{
    // Start is called before the first frame update
    public Skill InfoSkill4;
    public static SkillSlotBox4 instance;
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
        if (InfoSkill4 != PlayerManager.instance.player.skills[3])
        {
            InfoSkill4 = PlayerManager.instance.player.skills[3];
            PlayerManager.instance.player.timeSkills[3] = InfoSkill4.cooldown;
            GameObject player = GameObject.Find("Player");
            SkillToSpawn = InfoSkill4.prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            skillObject = newSkill.GetComponent<MonoBehaviour>();
            textSkill.text = InfoSkill4.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill4.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;

            
        }
        else
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
        }

    }
        
    private void Update()
    {
        if (InfoSkill4 != PlayerManager.instance.player.skills[3] && PlayerManager.instance.player.skills[3] != null)
        {
            InfoSkill4 = PlayerManager.instance.player.skills[3];
            textSkill.text = InfoSkill4.name;
            GameObject player = GameObject.Find("Player");
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill4.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;

            SkillToSpawn = InfoSkill4.prefabSkill;
          
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            skillObject = newSkill.GetComponent<MonoBehaviour>();
            check = false;
        }
        else if(PlayerManager.instance.player.skills[3]==null)
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
            InfoSkill4 = null;
        }
        if (InfoSkill4 != null)
        {
            if (InfoSkill4.isCooldown)
            {

                PlayerManager.instance.player.timeSkills[3] += Time.deltaTime;
            }
            float radio = (InfoSkill4.cooldown - PlayerManager.instance.player.timeSkills[3]) / InfoSkill4.cooldown;
            radio = Mathf.Max(radio, 0);
            fadeCooldown.rectTransform.localScale = new Vector3(1, radio, 1);
            InfoSkill4.CooldownSkill(PlayerManager.instance.player.timeSkills[3]);
            if (ManaSystem.instance.MpPlayer >= InfoSkill4.CheckMana() && (PlayerManager.instance.player.timeSkills[3] >= InfoSkill4.cooldown) && Input.GetKeyDown(KeyCode.F) && !InfoSkill4.isUsing)
            {
                (skillObject as ISkill).UseSkill();
                PlayerManager.instance.player.timeSkills[3] = InfoSkill4.InteractSkill();

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
