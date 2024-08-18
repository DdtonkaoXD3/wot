using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Endless : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int limitLevel = 100;
    [SerializeField] private Text currentScore, scoreText, MaxScoreText;
    [SerializeField] private int limitMax=10;
    public GameObject gameOverText, UIStatus, SkillSlot, Swap;
    public int score=0;
    public int maxScore;
    public bool gameOver;
    public static Endless instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        currentScore.text = "Score : " + score;
        if (score >=  limitLevel)
        {
            HpEnemy.instance.endlessBuff += 10;
            SpawnThiny.instance.limit += 1;
            limitLevel += 100;
            limitMax += limitMax;
        }
        
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        UIStatus.SetActive(false);
        SkillSlot.SetActive(false);
        Swap.SetActive(false);
        maxScore = Mathf.Max(maxScore, score);
        scoreText.text = "Score : " + score;
        MaxScoreText.text = "Max Score : " + maxScore;
        PlayerPrefs.SetInt("Score", maxScore);
    }
}
