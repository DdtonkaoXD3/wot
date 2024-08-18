using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThiny : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemy = new List<GameObject>();
    public float timeElapsed = 0f;
    public float ItemCycle = 10.0f; //เกิดทุกๆ 5 วิ
    public static SpawnThiny instance;
    public static List<GameObject> limitThiny = new List<GameObject>();
    [SerializeField] public int limit = 5;
    public int ThinyCount=0;
    [SerializeField] private Vector2 FirstDistanceSpawn;
    [SerializeField] private Vector2 SecondDistanceSpawn;
    public static List<GameObject> GetSlimeList()
    {
        return limitThiny;
    }
    private void Awake()
    {
        instance = this;
    }
    private bool fullEnemy = false;
    void Start()
    {
        ThinyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fullEnemy)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
        }
        //เวลาผ่านไป x วินาที
        if (timeElapsed > ItemCycle)
        {
            GameObject temp;
            if (!fullEnemy)
            {
                int i = Random.Range(0, enemy.Count);
                temp = (GameObject)Instantiate(enemy[i], new Vector3(Random.Range(FirstDistanceSpawn.x, SecondDistanceSpawn.x), Random.Range(FirstDistanceSpawn.y,SecondDistanceSpawn.y), 0f), Quaternion.identity); //โคลน enemy
                                                                                                                                             //Vector3 pos = temp.transform.position; //ให้ temp ปรากฏที่ตำแหน่ง //ไม่ใช้ก็ได  //สุ่มตำแหน่งที่ปรากฏ
            }

            timeElapsed -= ItemCycle; //ถ้าเข้าเงื่อนไขลบ timeElapsed ด้วย ItemCycle หรือก็คือ ทำให้เหลือ 0
        }
        if (ThinyCount >= limit)
        {
            fullEnemy = true;
        }
        else
        {
            fullEnemy = false;

        }
    }
}
