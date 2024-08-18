using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EliminateThiny : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text ScoreText;
    [SerializeField] private int maxEliminate;
    public int eliminateEnemy, constantCount = 0;
    public static EliminateThiny instance;
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
        if (constantCount < SpawnThiny.limitThiny.Count)
            constantCount++;
        if (SpawnThiny.limitThiny.Count < constantCount)
        {
            constantCount--;
            eliminateEnemy++;
            ScoreText.text = "Eliminate Thiny " + eliminateEnemy + " / " + maxEliminate;
        }

        if (eliminateEnemy >= 15)
        {
            SceneManagerClass.instance.LoadScene("StoryMode");
        }

    }
}
