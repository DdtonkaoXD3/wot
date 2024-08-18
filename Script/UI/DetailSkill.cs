using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetailSkill : MonoBehaviour
{
    [SerializeField] private GameObject skillBox, target;
    // Start is called before the first frame update
    void Start()
    {
                foreach (Skill thatskill in Data.instance.skillList)
                {
                        GameObject skill = Instantiate(skillBox, target.transform.position, Quaternion.identity, target.transform);
                        skill.GetComponent<Button>().onClick.AddListener(delegate { OnClickSkill(thatskill); });
                        skill.GetComponentInChildren<Text>().text = thatskill.name;
                        skill.GetComponent<Image>().color = thatskill.elemental.elementalColor;
                }
          
     }
        public void OnClickSkill(Skill thatskill)
        {
            for (int i = 0; i < 4; i++)
            {
                if (ShowSkill.instance.thiny.skills[i] == null)
                {
                    ShowSkill.instance.thiny.skills[i] = thatskill;
                    break;
                }
            }
        }

    // Update is called once per fram
}
