using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : MonoBehaviour
{
    
    public static ResourceSystem instance;
    public int coin;
    public int token;
    public int chapter;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coin = PlayerPrefs.GetInt("Coin");
        token = PlayerPrefs.GetInt("Token");
        chapter = PlayerPrefs.GetInt("Chapter");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    public void SimpleSaveGame(int ch)
    {
        
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("Token", token);
        PlayerPrefs.SetInt("Chapter", ch);
    }
    public void SimpleSaveCoin()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void receiveCoin()
    {
        coin++;
    }
}
