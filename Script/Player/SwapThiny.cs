using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwapThiny : MonoBehaviour
{
    [SerializeField] Team team;
    public List<PlayerThiny> swapThiny = new List<PlayerThiny>();
    [SerializeField] private GameObject player;
    PlayerManager manager;
    public bool call=false;
    public List<Image> swapImage = new List<Image>();
    public List<Text> swapText = new List<Text>();
    public List<Image> swapElemental = new List<Image>();
    //public List<Image> showThiny = new List<Image>();
    public static SwapThiny instance;
    public int countThiny = 0;
    void Awake()
    {/*
        GameObject thiny1 = Instantiate(swapThiny[0].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
        thiny1.SetActive(true);
        GameObject thiny2 = Instantiate(swapThiny[1].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
        thiny2.SetActive(false);
        GameObject thiny3 = Instantiate(swapThiny[2].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
        thiny3.SetActive(false);*/
        instance = this;
        manager = PlayerManager.instance;
        for(int i =0; i< team.thinyTeam.Count; i++)
        {
            
            if (team.thinyTeam[i] == null)
            {
                
                for(int j =i; j< team.thinyTeam.Count; j++)
                {
                    swapThiny[j] = null;
                    swapImage[j].color = new Color32(0,0,0,255);
                    
                    swapElemental[j].color = new Color32(0,0,0,0);
                }
                break;
            }
            else
            {
                swapThiny[i] = team.thinyTeam[i];
                swapThiny[i].isDied = false;
                swapImage[i].color = swapThiny[i].colorThiny;
                swapElemental[i].color = swapThiny[i].elemental.elementalColor;
                //showThiny[i].sprite = swapThiny[i].character;
                countThiny++;
                if (i != 0)
                {
                    swapThiny[i].firstTime = true;
                }
            }
        }
        
        
        /*swapThiny[2] = team.thinyTeam[2];
        
        swapThiny[1].firstTime = true;
        swapThiny[2].firstTime = true;
        swapImage[0].color = swapThiny[0].colorThiny;
        swapImage[1].color = swapThiny[1].colorThiny;
        
        swapElemental[1].color = swapThiny[1].elemental.elementalColor;*/
        GameObject thiny = Instantiate(swapThiny[0].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
        manager.player = swapThiny[0];
        swapThiny[0].FirstShow();



    }
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if ((Input.GetKeyDown(KeyCode.Alpha1) && (manager.player != swapThiny[0]) && !(swapThiny[0].isDied)) || (call&& !(swapThiny[0].isDied)))
        {
            GameObject thiny = Instantiate(swapThiny[0].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
            manager.player = swapThiny[0];
            swapImage[0].color = swapThiny[0].showColor();
            swapImage[1].color = swapThiny[1].showColor();
            swapImage[2].color = swapThiny[2].showColor();
            swapElemental[0].color = swapThiny[0].elemental.elementalColor;
            swapElemental[1].color = swapThiny[1].elemental.elementalColor;
            swapElemental[2].color = swapThiny[2].elemental.elementalColor;
            //showThiny[0].sprite = swapThiny[0].character;
            //showThiny[1].sprite = swapThiny[1].character;
            //showThiny[2].sprite = swapThiny[2].character;
            swapText[0].text = "1";
            swapText[1].text = "2";
            swapText[2].text = "3";

            call = false;
        }
        if(swapThiny[1] != null)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha2) && (manager.player != swapThiny[1]) && !(swapThiny[1].isDied)) || (call && !(swapThiny[1].isDied))){
                GameObject thiny = Instantiate(swapThiny[1].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
                PlayerManager.instance.player = swapThiny[1];
                swapImage[0].color = swapThiny[1].showColor();
                swapImage[1].color = swapThiny[0].showColor();
                swapImage[2].color = swapThiny[2].showColor();
                swapElemental[0].color = swapThiny[1].elemental.elementalColor;
                swapElemental[1].color = swapThiny[0].elemental.elementalColor;
                swapElemental[2].color = swapThiny[2].elemental.elementalColor;
                //showThiny[0].sprite = swapThiny[1].character;
                //showThiny[1].sprite = swapThiny[0].character;
                //showThiny[2].sprite = swapThiny[2].character;
                swapText[0].text = "2";
                swapText[1].text = "1";
                swapText[2].text = "3";

                call = false;
            }
        }
        if(swapThiny[2] != null)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha3) && (manager.player != swapThiny[2]) && !(swapThiny[2].isDied)) || (call && !(swapThiny[2].isDied)))
            {
                GameObject thiny = Instantiate(swapThiny[2].thinyPrefab, player.transform.position, Quaternion.identity, player.transform);
                PlayerManager.instance.player = swapThiny[2];
                swapImage[0].color = swapThiny[2].showColor();
                swapImage[1].color = swapThiny[0].showColor();
                swapImage[2].color = swapThiny[1].showColor();
                swapElemental[0].color = swapThiny[2].elemental.elementalColor;
                swapElemental[1].color = swapThiny[0].elemental.elementalColor;
                swapElemental[2].color = swapThiny[1].elemental.elementalColor;
                //showThiny[0].sprite = swapThiny[2].character;
                //showThiny[1].sprite = swapThiny[0].character;
                //showThiny[2].sprite = swapThiny[1].character;
                swapText[0].text = "3";
                swapText[1].text = "1";
                swapText[2].text = "2";
                call = false;
            }
            
        }
        if(countThiny == 1)
        {
            if ((swapThiny[0].isDied) && (swapThiny[1] == null) && (swapThiny[2] == null))
            {
                if (Endless.instance == null)
                {
                    GameController.instance.GameOver();
                }
                else
                {
                    Endless.instance.GameOver();
                }

            }
        }
        else if(countThiny == 2)
        {
            if ((swapThiny[0].isDied) && (swapThiny[1].isDied) && (swapThiny[2] == null))
            {
                if (Endless.instance == null)
                {
                    GameController.instance.GameOver();
                }
                else
                {
                    Endless.instance.GameOver();
                }

            }
        }
        else
        {
            if((swapThiny[0].isDied) && (swapThiny[1].isDied) && (swapThiny[2].isDied))
            {
                if(Endless.instance == null)
                {
                    GameController.instance.GameOver();
                }
                else
                {
                    Endless.instance.GameOver();
                }
                    
            }
        }
        
        
    }

}
