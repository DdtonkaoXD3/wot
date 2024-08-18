using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name;
    public PlayerThiny thiny { get; set; }
    [SerializeField] List<Image> skillImage = new List<Image>();
    [SerializeField] List<Text> skillText = new List<Text>();
    
    [SerializeField] Text thinyName;
    public static ShowSkill instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Name = PlayerPrefs.GetString("PlayerThiny");
        foreach (PlayerThiny player in Data.instance.playerList)
        {
            if(player.name == Name)
            {
                thiny = player;
            }
        }
        thinyName.text = thiny.name;
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
    }

    // Update is called once per frame
    void Update()
    {
        Name = PlayerPrefs.GetString("PlayerThiny");
        foreach (PlayerThiny player in Data.instance.playerList)
        {
            if (player.name == Name)
            {
                thiny = player;
            }
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
    }
    public void ResetSkill()
    {
        for (int i = 0; i < 4; i++) {

            thiny.skills[i] = null;
        }
    }
}
