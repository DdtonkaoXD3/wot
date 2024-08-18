using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] public EnemyThiny type;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        moveSpeed = type.spdBullet;
    }

    private void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HpEnemy enemyHealth = other.gameObject.GetComponent<HpEnemy>();
        //Indestructible indestructible = other.gameObject.GetComponent<Indestructible>(); //สิ่งก่อสร้าง
        if (other.gameObject.tag == "Player")
        {
            if (isEnemyProjectile)
            {
                HealthSystem.instance.AttackedPlayer(type.atk, type.elemental);
            }

            //Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if( other.gameObject.name == "Dr.Flask")
        {
            Flask.instance.FlaskGetDamage(type.atk);
            Destroy(gameObject);
        }
    }

    private void DetectFireDistance()
    {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
