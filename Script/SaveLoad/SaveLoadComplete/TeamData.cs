using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TeamSystem teamSystem = new TeamSystem();
    public static TeamData instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadTeamFromJson();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveTeamToJson();
        }
    }
    public void SaveTeamToJson()
    {
        teamSystem.thatTeams.Clear();
        for (int i = 0; i < 3; i++)
        {
            if(SetTeam.instance.team.thinyTeam[i] != null)
            {
                teamSystem.thatTeams.Add(SetTeam.instance.team.thinyTeam[i].name);
            }
            else
            {
                teamSystem.thatTeams.Add(null);
            }
            
        }
        string teamData = JsonUtility.ToJson(teamSystem);
        string filePath = Application.persistentDataPath + "/TeamData002.json";
        System.IO.File.WriteAllText(filePath, teamData);
        Debug.Log("Save Done");
        Debug.Log(filePath);
    }
    public void LoadTeamFromJson()
    {
        string filePath = Application.persistentDataPath + "/TeamData002.json";
        string teamData = System.IO.File.ReadAllText(filePath);
        teamSystem = JsonUtility.FromJson<TeamSystem>(teamData);
        Setgame(teamSystem);

        Debug.Log("Load Done");
    }
    public void Setgame(TeamSystem file)
    {
        int teamCount = 0;
        for(int slot=0; slot<3; slot++)
        {
                if(file.thatTeams[teamCount] != "") {
                    for (int count = 0; count < Data.instance.playerList.Count; count++)
                    {
                        if (file.thatTeams[teamCount] == Data.instance.playerList[count].name)
                        {
                            SetTeam.instance.team.thinyTeam[slot] = Data.instance.playerList[count];
                            teamCount++;
                            break;
                        }
                    }
                }
                else
                {
                    SetTeam.instance.team.thinyTeam[slot] = null;
                    teamCount++;
                }
        }
       /* for (int i = 0; i < Data.instance.playerList.Count; i++)
        {
            Data.instance.playerList[i].isHaving = file.boolPlayer[i];
        }
        for (int i = 0; i < Data.instance.skillList.Count; i++)
        {
            Data.instance.skillList[i].isHaving = file.boolSkill[i];
        }
        /*for (int saveSkill = 0; saveSkill < file.thatSkill.Count; saveSkill++)
        {
            for (int countSkill = 0; countSkill < 4; countSkill++)
            {
                //
                string nameSkill = "";
                if (file.playerSkill[saveSkill][countSkill] != null)
                {
                    nameSkill = file.playerSkill[saveSkill][countSkill];
                }
                else
                {
                    continue;
                }
                //เช็คสกิล
                for (int k = 0; k < Data.instance.skillList.Count; k++)
                {
                    if (nameSkill == Data.instance.skillList[i].name)
                    {
                        Data.instance.playerList[i].skills[j] = Data.instance.skillList[k];
                        break;
                    }
                }

            }*/

        /*for(int skillSave=0; skillSave< file.thatSkills.Count; skillSave++)
        {*/
        /*int skillSave = 0;
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
        */
        //}
    }
}
[System.Serializable]
public class TeamSystem
{
    public List<string> thatTeams = new List<string>();
}

