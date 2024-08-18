using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyThiny type;
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockbackedEnemy knockback;


    private void Awake()
    {
        knockback = GetComponent<KnockbackedEnemy>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (knockback.gettingKnockedBack) { return; }

        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }
}
