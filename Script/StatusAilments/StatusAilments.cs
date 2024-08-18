using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusAilments : MonoBehaviour
{
    public static StatusAilments instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stun(GameObject thiny, float distance)
    {
        if(thiny.gameObject.tag == "Enemy")
        {
            EnemyMovement enemyM = GetComponent<EnemyMovement>();
            enemyM.moveSpeed = 0f;
            StartCoroutine(stunEnemy(enemyM,distance));
        }else if (thiny.gameObject.tag == "Player")
        {
            PlayerManager.instance.Speed = 0f;
            StartCoroutine(stunPlayer(distance));
        }
    }
    IEnumerator stunPlayer(float distance)
    {
        yield return new WaitForSeconds(distance);
        PlayerManager.instance.Speed = PlayerManager.instance.player.moveSpeed;
    }
    IEnumerator stunEnemy(EnemyMovement enemyM, float distance)
    {
        yield return new WaitForSeconds(distance);
        enemyM.moveSpeed = enemyM.enemy.type.moveSpeed;
    }
    public void Slow(GameObject thiny, float distance, float slowPercent)
    {
        if (thiny.gameObject.tag == "Enemy")
        {
            EnemyMovement enemyM = GetComponent<EnemyMovement>();
            enemyM.moveSpeed = slowPercent * enemyM.moveSpeed;
            StartCoroutine(stunEnemy(enemyM, distance));
        }
        else if (thiny.gameObject.tag == "Player")
        {
            PlayerManager.instance.Speed = PlayerManager.instance.Speed*slowPercent;
            StartCoroutine(stunPlayer(distance));
        }
    }
}
