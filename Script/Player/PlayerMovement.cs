using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D rb;
    public static PlayerMovement instance;
    [SerializeField] private GameObject graphic;
    Animator anim;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(graphic.GetComponent<Animator>() != null)
        {
            anim = graphic.GetComponent<Animator>();
        }*/
        moveInput.x = Input.GetAxis("Horizontal") * PlayerManager.instance.Speed;
        moveInput.y = Input.GetAxis("Vertical") * PlayerManager.instance.Speed;
        rb.velocity = new Vector2(moveInput.x, moveInput.y);
        

    }
}
