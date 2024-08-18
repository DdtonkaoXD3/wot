using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator anim;
    Vector2 targetDirection;
    public void Attack()
    {
        if(GameObject.FindWithTag("Player") != null)
        {
            
            StartCoroutine(PlayAnimAttack());
            StartCoroutine(AttackPlayer());
            
        }
        
    }
    IEnumerator PlayAnimAttack()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Attack", false);
    }
    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        if (GameObject.FindWithTag("Player") != null)
        {
            targetDirection = GameObject.FindWithTag("Player").transform.position - transform.position;
        }
        if (GameObject.Find("Dr.Flask") != null)  //ถ้า targetObject เป็นค่าว่าง ให้...
        {
            targetDirection = GameObject.Find("Dr.Flask").transform.position - transform.position;
        }
        EnemySearchComponent search = GetComponent<EnemySearchComponent>();
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.transform.right = targetDirection;
        newBullet.GetComponent<EnemyProjectile>().type = search.type;
    }
}
