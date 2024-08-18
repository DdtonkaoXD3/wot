using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThinyCanUse : MonoBehaviour
{
    [SerializeField] GameObject target, thinyButton;
    public bool done = false;
    private void Start()
    {
        //InventoryData.instance.LoadFromJson();
    }
    void Update()
    {

        if (Data.instance != null && !done)
        {
            foreach (PlayerThiny thatThiny in Data.instance.playerList)
            {
                if (thatThiny.isHaving)
                {
                    GameObject skill = Instantiate(thinyButton, target.transform.position, Quaternion.identity, target.transform);
                    skill.GetComponent<Button>().onClick.AddListener(delegate { OnClickThiny(thatThiny); });
                    skill.GetComponentInChildren<Text>().text = thatThiny.name;
                    skill.GetComponent<Image>().color = thatThiny.elemental.elementalColor;
                }
            }
            done = true;
        }
    }
    public void OnClickThiny(PlayerThiny thatThiny)
    {
        for (int i = 0; i < 4; i++)
        {
            if (ShowThiny.instance.team.thinyTeam[i] == null)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (thatThiny == ShowThiny.instance.team.thinyTeam[j])
                    {
                        break;


                    }
                    else
                    {
                        if (j == i)
                        {
                            ShowThiny.instance.team.thinyTeam[j] = thatThiny;
                        }
                    }
                }
                break;

            }


        }
    }
}
