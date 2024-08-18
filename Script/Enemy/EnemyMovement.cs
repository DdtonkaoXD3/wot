using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public float DistanceBetween;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    [SerializeField] bool isRange =false;
    //code copy
    private Vector2 moveDir;
    public EnemySearchComponent enemy;
    public static EnemyMovement instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<EnemySearchComponent>();
        moveSpeed = enemy.type.moveSpeed;
        if (target == null)  //ถ้า targetObject เป็นค่าว่าง ให้...
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
         if (GameObject.Find("Dr.Flask") != null)  //ถ้า targetObject เป็นค่าว่าง ให้...
        {
            target = GameObject.Find("Dr.Flask");
        }
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
        

    // Update is called once per frame
    void Update()
    {
        if (!HpEnemy.instance.death)
        {
            if (target != null && !isRange)
            {
                MoveTo();
            }
            if(target == null && GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindGameObjectWithTag("Player");
            }
            
            //rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
            //หลัก //transform.position = Vector2.MoveTowards(this.transform.position, (target.transform.position), moveSpeed * Time.deltaTime);

            animator.SetBool("walk", true);
            /*DistanceBetween = Vector2.Distance(transform.position, target.transform.position);
            Vector2 direction = target.transform.position - transform.position;
            //if (DistanceBetween < distance)
            //{
                transform.position = Vector2.MoveTowards(this.transform.position, (target.transform.position), speed * Time.deltaTime);
                animator.SetBool("walk", true);
                if (direction.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (direction.x > 0)
                {
                    spriteRenderer.flipX = false;
                }

            }
            else
            {
                animator.SetBool("walk", false);
            }*/
        }

    }
    public void MoveTo()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, (target.transform.position), moveSpeed * Time.deltaTime);
            
        }
       
       
    }
    public void StopMoving()
    {
        transform.position = Vector3.zero;
    }
}
