using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayBlastArea : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyMovement enemyM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(destroyThis());
    }
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyM = other.GetComponent<EnemyMovement>();
            enemyM.moveSpeed = enemyM.moveSpeed * 0.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyM = other.GetComponent<EnemyMovement>();
            enemyM.moveSpeed = enemyM.enemy.type.moveSpeed;
        }
    }
}
