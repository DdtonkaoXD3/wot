using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowThiny : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public Team team;
    [SerializeField] List<Image> skillImage = new List<Image>();
    [SerializeField] List<Text> skillText = new List<Text>();

    public static ShowThiny instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (team.thinyTeam[i] != null)
            {
                skillImage[i].color = team.thinyTeam[i].elemental.elementalColor;
                skillText[i].text = team.thinyTeam[i].name;
            }
            else
            {
                skillImage[i].color = new Color32(255, 255, 255, 255);
                skillText[i].text = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (team.thinyTeam[i] != null)
            {
                skillImage[i].color = team.thinyTeam[i].elemental.elementalColor;
                skillText[i].text = team.thinyTeam[i].name;
            }
            else
            {
                skillImage[i].color = new Color32(255, 255, 255, 255);
                skillText[i].text = "";
            }
        }
    }
    public void ResetSkill()
    {
        for (int i = 0; i < 3; i++)
        {

            team.thinyTeam[i] = null;
        }
    }
}
