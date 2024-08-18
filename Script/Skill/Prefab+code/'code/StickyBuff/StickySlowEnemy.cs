using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickySlowEnemy : MonoBehaviour
{
    [SerializeField] private Elemental elemental;
    EnemyMovement enemyM;
    GameObject effect;
    GameObject stick;
    // Start is called before the first frame update
    void Start()
    {
        effect = Resources.Load<GameObject>("Sticky");
        stick = Instantiate(effect, transform.position/*+ offset*/, Quaternion.Euler(new Vector3(0, 0, 0)), transform);
        elemental = PlayerManager.instance.player.elemental;
        enemyM = GetComponent<EnemyMovement>();
        enemyM.moveSpeed = enemyM.moveSpeed * 0.3f;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(destroyThis());
    }
    
 
        
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(3f);
        enemyM.moveSpeed = enemyM.enemy.type.moveSpeed;
        Destroy(stick);
        Destroy(this);
    }
}
