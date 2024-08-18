using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GachaSystem : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float randomType = 0f;
    [SerializeField] private int random;
    [SerializeField] private PlayerThiny thiny;
    [SerializeField] private GameObject show1, show10;
    //[SerializeField] private List<Text> typeTexts = new List<Text>();
    [SerializeField] private List<Text> nameTexts = new List<Text>();
    [SerializeField] private List<Text> newTexts = new List<Text>();
    [SerializeField] private Text typeText;
    [SerializeField] private Text nameText;
    public Text newText;
    void Start()
    {
        show1.SetActive(false);
        show10.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnGacha()
    {
        if(ResourceSystem.instance.coin >= 5)
        {
            ResourceSystem.instance.coin -= 5;
            randomType = Random.Range(0f, 101f);
            if (randomType >= 0f && randomType <= 20f)
            {
                show1.SetActive(true);


                random = Random.Range(0, Data.instance.playerList.Count);
                // typeText.text = "Thiny";
                nameText.text = "Thiny : " + Data.instance.playerList[random].name;
                if (!Data.instance.playerList[random].isHaving)
                {
                    newText.enabled = true;
                }
                Data.instance.playerList[random].isHaving = true;
            }
            else
            {
                show1.SetActive(true);
                //สุ่มจาก 0 ถึง จำนวนนั้น-1
                random = Random.Range(0, Data.instance.skillList.Count);
                // typeText.text = "Skill";
                nameText.text = "Skill : " + Data.instance.skillList[random].name;
                if (!Data.instance.skillList[random].isHaving)
                {
                    newText.enabled = true;
                }
                Data.instance.skillList[random].isHaving = true;
            }
        
        }
#if UNITY_EDITOR
        Data.instance.SaveAll();
#endif


    }
    public void OnGacha10x()
    {
        if(ResourceSystem.instance.coin >= 50)
        {
            ResourceSystem.instance.coin -= 50;
            
            for (int i = 0; i < 10; i++)
            {
                show10.SetActive(true);
                randomType = Random.Range(0f, 101f);
                if (randomType >= 0f && randomType <= 20f)
                {
                    random = Random.Range(0, Data.instance.playerList.Count);
                    // typeTexts[i].text = "Thiny";
                    nameTexts[i].text = "Thiny : " + Data.instance.playerList[random].name;
                    if (!Data.instance.playerList[random].isHaving)
                    {
                        newTexts[i].enabled = true;
                    }
                    Data.instance.playerList[random].isHaving = true;
                }
                else
                {
                    random = Random.Range(0, Data.instance.skillList.Count);
                    //typeTexts[i].text = "Skill";
                    nameTexts[i].text = "Skill : " + Data.instance.skillList[random].name;
                    if (!Data.instance.skillList[random].isHaving)
                    {
                        newTexts[i].enabled = true;
                    }
                    Data.instance.skillList[random].isHaving = true;
                }
            }
            
        }
#if UNITY_EDITOR
        Data.instance.SaveAll();
#endif



    }
    public void OnClosex1()
    {
        ResourceSystem.instance.SimpleSaveCoin();
        show1.SetActive(false);
        newText.enabled = false;
    }
    public void OnClosex10()
    {
        ResourceSystem.instance.SimpleSaveCoin();
        show10.SetActive(false);
        for(int i=0; i<10; i++)
        {
            newTexts[i].enabled = false;
        }
    }
    
}
