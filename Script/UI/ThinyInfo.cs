using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThinyInfo : MonoBehaviour
{
    public string Name;
    public Text nameThiny, infoThiny, elementalName;
    public Image showThiny, elemental;
    public string range;
    public float atkspeed;
    public PlayerThiny firstThiny;
    [SerializeField] List<Image> skillImage = new List<Image>();
    [SerializeField] List<Text> skillText = new List<Text>();
    // Start is called before the first frame update

    void Start()
    {
        InventoryData.instance.LoadFromJson();
        OnClickThiny(firstThiny);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickThiny(PlayerThiny thiny)
    {
 
        PlayerPrefs.SetString("PlayerThiny", thiny.name);
        nameThiny.text = thiny.name;
        elemental.sprite = thiny.elemental.elementalLogo;
        elementalName.text = thiny.elemental.name;
        showThiny.sprite = thiny.character;
        atkspeed = (-30f*(thiny.atkSpeed + 1)) + 100f;
        if (thiny.isRange)
        {
            range = "Range";

        }
        else
        {
            range = "Melee";
        }
        for (int i = 0; i < 4; i++)
        {
            if (thiny.skills[i] != null)
            {
                skillImage[i].color = thiny.skills[i].elemental.elementalColor;
                skillText[i].text = thiny.skills[i].name;
            }
            else
            {
                skillImage[i].color = new Color32(255, 255, 255, 255);
                skillText[i].text = "";
            }
        }

        infoThiny.text = "HP : " + thiny.hp.ToString() + "\nDEF: " + thiny.def.ToString() + "\nMP : " + thiny.mp.ToString() + "\nATK : " + thiny.atk.ToString() + "\nATK Range : " + range + "\nATK Speed : " + atkspeed.ToString() + "\nCritical Rate : " + thiny.criticalRate.ToString() + "%\nCritical Damage : " + thiny.criticalDamage.ToString() + "%\nMove Speed : " + thiny.moveSpeed*10; 

    }
}
