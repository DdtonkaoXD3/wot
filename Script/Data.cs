using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Data : MonoBehaviour
{
    public List<Skill> skillList = new List<Skill>();
    public List<PlayerThiny> playerList = new List<PlayerThiny>();
    //[SerializeField] InventoryData thinyInventory;
    public static Data instance;
    public PlayerThiny mainPlayer;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public string SaveData()
    {
        thinyInventory = new InventoryData(this);
        Debug.Log(name+ " "+playerList.Count);
        return JsonUtility.ToJson(thinyInventory);
    }
    public void LoadData(string data)
    {
        thinyInventory = JsonUtility.FromJson<InventoryData>(data);
        SetSkillThiny(thinyInventory);
    }
    public void SetSkillThiny(InventoryData inventoryData)
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            string loadPath = "ThPlayer/" + inventoryData.player[i].playerFilename;
            for (int j=0; j< 4; j++)
            {
                playerList[i].skills[j] = Resources.Load<Skill>(loadPath), inventoryData.player[i].skill[j];
                //playerList[i].skills[j] = Resources.Load<Skill>(loadPath); (inventoryData.player[i].skill[j]);
            }
            
        }
    }

    [System.Serializable]
    public class InventoryData
    {
        public PlayerData[] player;
        public InventoryData(Data data)
        {
            player = new PlayerData[data.playerList.Count];
            for(int i =0; i < data.playerList.Count; i++)
            {
                    player[i] = new PlayerData(data.playerList[i]);
            }
                    
        }

    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerFilename;
        public Skill[] skill = new Skill[4];

            public PlayerData(PlayerThiny thiny)
            {
                playerFilename = thiny.name;
                skill[0] = thiny.skills[0];
                skill[1] = thiny.skills[1];
                skill[2] = thiny.skills[2];
                skill[3] = thiny.skills[3];
            }
    }*/
    /*   public ThinyData(PlayerThiny thiny)
        {
            ThinyFileName = thiny.name;
            isHaving = thiny.isHaving;
        }*/
    public void SaveAll()
    {
        foreach (PlayerThiny player in playerList)
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(player);
#endif

            //JsonUtility.ToJson(player);
        }
        foreach (Skill skill in skillList)
        {
#if UNITY_EDITOR
            //EditorUtility.SetDirty(skill);
#endif
           // JsonUtility.ToJson(skill);
        }


    }
    public void SaveTeam()
    {
        //EditorUtility.SetDirty(ShowThiny.instance.team);
    }

}
