using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public Skill firstSkill;
    public GameObject skillBox;
    public GameObject target;
    public Text skillName, skillDescript,skillElementalText,skillDamage, skillMana;
    public Image skillElemental;
    void Start()
    {
        InventoryData.instance.LoadFromJson();
        foreach (Skill thatskill in Data.instance.skillList)
        {

            GameObject skill = Instantiate(skillBox, target.transform.position, Quaternion.identity, target.transform);
            skill.GetComponent<Button>().onClick.AddListener(delegate {ClickSkillInfo(thatskill); });
            skill.GetComponent<Image>().color = thatskill.elemental.elementalColor;
            skill.GetComponentInChildren<Text>().text = thatskill.name;
            if (!thatskill.isHaving)
            {
                skill.GetComponent<Button>().interactable = false;
            }
            
        }
        ClickSkillInfo(firstSkill);
    }
    public void ClickSkillInfo(Skill thatskill)
    {
        skillName.text = thatskill.name;
        skillElemental.sprite = thatskill.elemental.elementalLogo;
        skillElementalText.text = thatskill.elemental.name;
        skillDescript.text = "  \""+thatskill.description+"\"";
        skillDamage.text = "";


        if (thatskill.percentDamage)
        {
            skillDamage.text = "Damage: "+ thatskill.damage + "%";
        }
        else
        {
            skillDamage.text = "Damage: " + thatskill.damage;
        }
        if (thatskill.PercentCost)
        {
            skillMana.text = "Mana cost : " + thatskill.manaCost + "%";
        }
        else
        {
            skillMana.text = "Mana cost : " + thatskill.manaCost;
        }
    }
}
