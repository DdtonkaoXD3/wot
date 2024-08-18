using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text taskText;
    public GameObject UIStatus, SkillSlot, Swap, victory, gameOverText;
    public bool gameOver=false;
    public static GameController instance;
    public int nextChapter=0;
    //ใช้
    public bool boolEliminate, boolProtect, boolAreaZone, boolCollect, boolDestroy;

    //ชนิด enemy, object
    public List<EnemyThiny> typeEnemy = new List<EnemyThiny>();
    public List<string> EnemyName = new List<string>();
    public List<string> typeObject = new List<string>();

    //จำนวนที่ต้องการ
    public List<int> countEliminate,countDestroy = new List<int>();
    public int countArea,countCollect,countTask;

    //จำนวนปัจจุบัน
    public List<int> currentEliminate, currentDestroy = new List<int>();
    public int currentArea, currentCollect, currentProtect;

    //เช็คว่ากำจัดครบรึยัง
    public List<bool> task, taskEliminate, taskDestroy = new List<bool>();
    private string e="",p = "", a = "", c = "", d="";
    public List<string> elist, dlist = new List<string>();

    private bool boolvictory = false;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < typeEnemy.Count ; i++)
        {
    
            EnemyName.Add(typeEnemy[i].name);
            taskEliminate.Add(false);
        }
        for (int i = 1; i <= typeObject.Count; i++)
        {
            taskDestroy.Add(false);
        }
        if (boolEliminate) countTask += taskEliminate.Count;
        if (boolProtect) countTask++;
        if (boolAreaZone) countTask++;
        if (boolCollect) countTask++;
        if (boolDestroy) countTask += taskDestroy.Count;
    }

    // Update is called once per frame
    void Update()
    {
        taskText.text = "Task\n"+ e + p + a + c + d;
        if (task.Count >= countTask && task.Count != 0)
        {
            Victory();
        }
        Eliminate();
        Protect();
        Area();
        Collect();
        DestroyObject();
    }
    public void GameOver()
    {
        if (!boolvictory)
        {
            ResourceSystem.instance.SimpleSaveCoin();
            gameOverText.SetActive(true);
            UIStatus.SetActive(false);
            SkillSlot.SetActive(false);
            Swap.SetActive(false);
        }
       
    }
    public void Victory()
    {
        if(nextChapter > ResourceSystem.instance.chapter)
        {
            ResourceSystem.instance.SimpleSaveGame(nextChapter);
        }
        ResourceSystem.instance.SimpleSaveCoin();
        
        boolvictory = true;
        victory.SetActive(true);
        UIStatus.SetActive(false);
        SkillSlot.SetActive(false);
        Swap.SetActive(false);
        
    }
    public void Eliminate()
    {
        if (boolEliminate)
        {
            e = "";
            // Console.Write(firstlist.Contains(4));  ตรวจสอบว่ามีจริงไหม
            for ( int i=0; i< typeEnemy.Count; i++){
                
                e +=  "- Eliminate " + EnemyName[i] +" "+ currentEliminate[i] +" / "+ countEliminate[i] + "\n";
                if ((currentEliminate[i] >= countEliminate[i]) && !taskEliminate[i])
                {
                    task.Add(true);
                    taskEliminate[i] = true;
                }
            }
        }
    }
    
    public void Protect()
    {
        if (boolProtect)
        {
            p = "- Protect Dr.Flask " + currentProtect + " / 1\n";
            if (currentProtect >= 1)
            {
                task.Add(true);
                boolProtect = false;
            }
        }
        
    }
    public void Area()
    {
        if (boolAreaZone)
        {
            a = "- Clear Area "+ currentArea +" / " + countArea + "\n";
            if (currentArea >= countArea)
            {
                task.Add(true);
                boolAreaZone = false;
            }
        }
    }
    public void Collect()
    {
        if (boolCollect)
        {
            c = "- Collect Key " +currentCollect + " / " +countCollect +"\n";
            if (currentCollect >= countCollect)
            {
                task.Add(true);
                boolCollect = false;
            }
        }
    }
    public void DestroyObject()
    {
        if (boolDestroy)
        {
            d = "";
            for (int i = 0; i < typeObject.Count; i++)
            {
                d += "- Destroy " + typeObject[i] + " " + currentDestroy[i] + " / " + countDestroy[i] + "\n";
                if ((currentDestroy[i] >= countDestroy[i]) && !taskDestroy[i])
                {
                    task.Add(true);
                    taskDestroy[i] = true;
                }
            }
        }
    }
    public void GetScore(EnemyThiny thiny)
    {
        if (typeEnemy.Contains(thiny))
        {
            int index = EnemyName.FindIndex(a => a.Contains(thiny.name));
            currentEliminate[index]++;
        }
    }
    public void DestroyObject(string ob)
    {
        if (typeObject.Contains(ob))
        {
            int index = typeObject.FindIndex(a => a.Contains(ob));
            currentDestroy[index]++;
        }
    }
}
