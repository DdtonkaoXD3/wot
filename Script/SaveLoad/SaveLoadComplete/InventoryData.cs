using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class InventoryData : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory = new Inventory();
    public static InventoryData instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Save Data");
            SaveToJson();
        }
    }
    public void SaveToJson()
    {
        inventory.boolPlayer.Clear();
        inventory.boolSkill.Clear();
        inventory.thatSkills.Clear();
        for (int i = 0; i < Data.instance.playerList.Count; i++)
        {
            inventory.boolPlayer.Add(Data.instance.playerList[i].isHaving);
            for (int j = 0; j < 4; j++)
            {
                if (Data.instance.playerList[i].skills[j] != null)
                {
                    inventory.thatSkills.Add(Data.instance.playerList[i].skills[j].name);
                }
                else
                {
                    inventory.thatSkills.Add("");
                }

            }

        }
        for (int i = 0; i < Data.instance.skillList.Count; i++)
        {
            inventory.boolSkill.Add(Data.instance.skillList[i].isHaving);
        }
        string inventoryData = JsonUtility.ToJson(inventory);
        string filePath = Application.persistentDataPath + "/wot002.json";
        System.IO.File.WriteAllText(filePath, inventoryData);
        Debug.Log("Save Done");
        Debug.Log(filePath);
    }
    public void LoadFromJson()
    {

        string filePath = Application.persistentDataPath + "/wot002.json";
        string inventoryData = System.IO.File.ReadAllText(filePath);
        inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        Setgame(inventory);

        Debug.Log("Load Done");
    }
    public void Setgame(Inventory file)
    {
        for (int i = 0; i < Data.instance.playerList.Count; i++)
        {
            Data.instance.playerList[i].isHaving = file.boolPlayer[i];
        }
        for (int i = 0; i < Data.instance.skillList.Count; i++)
        {
            Data.instance.skillList[i].isHaving = file.boolSkill[i];
        }
        for(int i=0; i < file.thatSkills.Count; i++)
        {
            for (int player = 0; player < file.boolPlayer.Count; player++)
            {
                for(int countSkill=0; countSkill<4; countSkill++)
                {
                    if (i < file.thatSkills.Count)
                    {
                        if (file.thatSkills[i] != "")
                        {
                            for (int z = 0; z < Data.instance.skillList.Count; z++)
                            {
                                if (file.thatSkills[i] == Data.instance.skillList[z].name)
                                {
                                    Data.instance.playerList[player].skills[countSkill] = Data.instance.skillList[z];
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            Data.instance.playerList[player].skills[countSkill] = null;
                            i++;
                        }
                    }
                    
                    
                }
                
                
            }
                       

                /* for (int skillSave = 0; skillSave < file.thatSkills.Count; skillSave++)
                 {
                     //int skillSave = 0;
                     for (int j = 0; j < Data.instance.playerList.Count; j++)
                     {
                         for (int skillSlot = 0; skillSlot < 4; skillSlot++)
                         {
                             if (file.thatSkills[skillSave] != "")
                             {
                                 for (int skill = 0; skill < Data.instance.skillList.Count; skill++)
                                 {
                                     if (file.thatSkills[skillSave] == Data.instance.skillList[skill].name)
                                     {
                                         Data.instance.playerList[j].skills[skillSlot] = Data.instance.skillList[skill];
                                         skillSave++;
                                         break;
                                     }
                                     else if (Data.instance.skillList[skill].name == "")
                                     {

                                     }

                                 }
                             }
                             else
                             {
                                 Data.instance.playerList[j].skills[skillSlot] = null;
                                 skillSave++;

                             }
                         }
                     }
                 }*/
        }
    }
}
//เก็บไฟล์ตาม class นี้
[System.Serializable]
public class Inventory
{

    public int goldCoins;
    public string playerName;
    public bool isHaving;

    public List<bool> boolPlayer = new List<bool>();
    public List<bool> boolSkill = new List<bool>();
    public List<string> thatSkills = new List<string>();
    public List<List<string>> playerSkill = new List<List<string>>();
}
