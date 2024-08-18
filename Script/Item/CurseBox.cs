using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float HpMax=500;
    [SerializeField] private float HpCurrent;
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
        
        if (HpCurrent <= 0)
        {
            GameController.instance.DestroyObject("Curse Boxs");
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
        if(collision.gameObject.tag == "MeleeAttack")
        {
            HpCurrent -= PlayerManager.instance.player.atk;
            hpbar.UpdateHealthBar(HpCurrent, HpMax);
        }
    }
}
