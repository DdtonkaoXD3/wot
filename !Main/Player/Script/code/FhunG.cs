using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FhunG : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public static FhunG instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (PlayerMovement.instance.moveInput.x != 0 || PlayerMovement.instance.moveInput.y != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    // Update is called once per frame
    public void FhunAttack(bool atk)
    {
        animator.SetBool("Attack", atk);
    }
}
