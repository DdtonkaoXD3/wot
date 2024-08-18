using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanUseSkill : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject target,SkillSlot;
    public bool done=false;
    public Elemental all;
    private void Start()
    {
    }
    void Update()
    {
        
        if(Data.instance != null && !done)
        {
            foreach (Skill thatskill in Data.instance.skillList)
            {
                if (((thatskill.elemental == ShowSkill.instance.thiny.elemental) || (thatskill.elemental == all)) && thatskill.isHaving)
                {
                    GameObject skill = Instantiate(SkillSlot, target.transform.position, Quaternion.identity, target.transform);
                    skill.GetComponent<Button>().onClick.AddListener(delegate { OnClickSkill(thatskill); });
                    skill.GetComponentInChildren<Text>().text = thatskill.name;
                    skill.GetComponent<Image>().color = thatskill.elemental.elementalColor;
                }
            }
            done = true;
        }
    }
    public void OnClickSkill(Skill thatskill)
    {
        for(int i=0; i<4; i++) { 
            if(ShowSkill.instance.thiny.skills[i] == null)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (thatskill == ShowSkill.instance.thiny.skills[j])
                    {
                        break;
                        

                    }
                    else
                    {
                        if (j==i)
                        {
                            ShowSkill.instance.thiny.skills[j] = thatskill;
                        }
                    }
                }
                break;

            }
            

        }
    }
}
