using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlounderStunEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyMovement enemyM = GetComponent<EnemyMovement>();
        enemyM.moveSpeed = 0f;
        StartCoroutine(stunEnemy(enemyM,3));
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator stunEnemy(EnemyMovement enemyM, float distance)
    {
        yield return new WaitForSeconds(distance);
        enemyM.moveSpeed = enemyM.enemy.type.moveSpeed;
        Destroy(this);
    }
}
