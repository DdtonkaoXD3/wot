using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileClayBlast : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 22f;
    float timeDestroy;
    [SerializeField] private GameObject Blast;
    private void Start()
    {

    }
    private void Update()
    {
        timeDestroy += Time.deltaTime;
        if (timeDestroy >= 3f)
        {
            Destroy(this.gameObject);
        }
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject newArrow = Instantiate(Blast, transform.position, transform.rotation);
        }
    }
}
