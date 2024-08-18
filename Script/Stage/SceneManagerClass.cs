using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;
public class SceneManagerClass : MonoBehaviour
{
    public Team team;
    public Text warningText;
    public float progress;
    public static SceneManagerClass instance;
    private void Awake()
    {
        instance = this;
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneGame(sceneName));
        
    }
    public void LoadSceneTeam(string sceneName)
    {
        if(team.thinyTeam[0] != null)
        {
            StartCoroutine(LoadSceneGame(sceneName));
        }
        else
        {
            warningText.enabled = true;
        }
            
    }


    IEnumerator LoadSceneGame(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            progress = Mathf.Clamp01(async.progress / 0.9f);
            if (progress == 1f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    public void SetZero()
    {
        PlayerPrefs.SetInt("Chapter", 0);
        PlayerPrefs.SetInt("Coin", 0);
        foreach (PlayerThiny player in Data.instance.playerList)
        {
            player.isHaving = false;
            for(int i=0; i<4; i++)
            {
                player.skills[i] = null;
            }
            //EditorUtility.SetDirty(player);
        }
        foreach (Skill skill in Data.instance.skillList)
        {
            skill.isHaving = false;
            //EditorUtility.SetDirty(skill);
        }
    }
    public void OnCreater()
    {
        foreach (PlayerThiny player in Data.instance.playerList)
        {
            player.isHaving = true;
            for (int i = 0; i < 4; i++)
            {
                player.skills[i] = null;
            }
            //EditorUtility.SetDirty(player);
        }
        foreach (Skill skill in Data.instance.skillList)
        {
            skill.isHaving = true;
            //EditorUtility.SetDirty(skill);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            LoadScene("Lobby");
        }
    }
    public void LoadSelectGame()
    {
        LoadScene("SelectGameMode");
    }
    public void LoadGacha()
    {
        LoadScene("Gacha");
    }
    public void LoadTeam()
    {
        LoadScene("ThinyTeam");
    }
    public void LoadThiny()
    {
        LoadScene("ThinyInfo");
    }
    public void LoadSkill()
    {
        LoadScene("SkillInfo");
    }
    public void LoadHandbook()
    {
        LoadScene("Handbook");
    }
}
