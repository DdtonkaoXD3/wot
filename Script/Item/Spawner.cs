using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float HpMax = 300;
    [SerializeField] private float HpCurrent;
    [SerializeField] private float timeCooldown=3f;
    [SerializeField] private float timing=0f;

    [SerializeField] private GameObject enemy;

    Rigidbody2D rb;
    HpBarEnemy hpbar;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        HpCurrent = HpMax;

        hpbar = GetComponentInChildren<HpBarEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if(timing >= timeCooldown)
        {
            GameObject temp = (GameObject)Instantiate(enemy, new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f), Random.Range(transform.position.y - 2f, transform.position.y + 2f), 0f), Quaternion.identity);
            timing = 0f;
        }
        if (HpCurrent <= 0)
        {
            GameController.instance.DestroyObject("Spawners");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            HpCurrent -= PlayerManager.instance.player.atk;
            hpbar.UpdateHealthBar(HpCurrent, HpMax);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "MeleeAttack")
        {
            HpCurrent -= PlayerManager.instance.player.atk;
            hpbar.UpdateHealthBar(HpCurrent, HpMax);
        }
    }
}
