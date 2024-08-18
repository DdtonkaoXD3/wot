using UnityEngine;
using UnityEngine.UI;
public class SkillSlotBox1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Skill InfoSkill1;
    public static SkillSlotBox1 instance;
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
        if(PlayerManager.instance.player.skills[0] != null)
        {
            InfoSkill1 = PlayerManager.instance.player.skills[0];
            PlayerManager.instance.player.timeSkills[0] = InfoSkill1.cooldown;
            GameObject player = GameObject.Find("Player");
            textSkill.text = InfoSkill1.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill1.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;

            SkillToSpawn = InfoSkill1.prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            skillObject = newSkill.GetComponent<MonoBehaviour>();
        }
        else
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112,128,144,255);
        }
        
    }
    private void Update()
    {
        if (InfoSkill1 != PlayerManager.instance.player.skills[0] && PlayerManager.instance.player.skills[0] !=null)
        {
            GameObject player = GameObject.Find("Player");
            InfoSkill1 =PlayerManager.instance.player.skills[0];
            SkillToSpawn = PlayerManager.instance.player.skills[0].prefabSkill;
            newSkill = Instantiate(SkillToSpawn, player.transform.position, Quaternion.identity, player.transform);
            
            textSkill.text = InfoSkill1.name;
            //image.color = new Color32(255, 255, 255, 100);
            GetComponent<Image>().color = InfoSkill1.elemental.elementalColor;
            //GetComponent<Image>().color = Color.red;
            InfoSkill1.timeSkill = InfoSkill1.cooldown;
            
            
            skillObject = newSkill.GetComponent<MonoBehaviour>();
            check = false;
        }
        else if(PlayerManager.instance.player.skills[0] == null)
        {
            textSkill.text = "";
            GetComponent<Image>().color = new Color32(112, 128, 144, 255);
            InfoSkill1 = null;
        }
        if (InfoSkill1 != null)
        {
            if (InfoSkill1.isCooldown)
            {
                PlayerManager.instance.player.timeSkills[0] += Time.deltaTime;
            }
            float radio = (InfoSkill1.cooldown - PlayerManager.instance.player.timeSkills[0]) / InfoSkill1.cooldown;
            radio = Mathf.Max(radio, 0);
            fadeCooldown.rectTransform.localScale = new Vector3(1, radio, 1);
            InfoSkill1.CooldownSkill(PlayerManager.instance.player.timeSkills[0]);
            if ((ManaSystem.instance.MpPlayer >= InfoSkill1.CheckMana() &&PlayerManager.instance.player.timeSkills[0] >= InfoSkill1.cooldown)&& Input.GetKeyDown(KeyCode.Q) && !InfoSkill1.isUsing)
            {
                (skillObject as ISkill).UseSkill();
                PlayerManager.instance.player.timeSkills[0] = InfoSkill1.InteractSkill();
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
