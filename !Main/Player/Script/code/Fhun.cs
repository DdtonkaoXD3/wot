using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fhun : MonoBehaviour
{
    private int beta = 1;
    [SerializeField] private PlayerThiny thiny;
    Vector3 offset = new Vector3(0, 0, 90f);
    private float nextShoot = 0f;
    private float TimeCooldown = 0.5f;
    public bool isAttack = false;
    public static Fhun instance;
    public GameObject reserve;
    public GameObject graphic;
    SpriteRenderer sprite;
    [SerializeField] Animator anim;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        sprite = graphic.GetComponent<SpriteRenderer>();
        TimeCooldown = thiny.atkSpeed;
    }
    private void Update()
    {
        //transform.localPosition = new Vector3(0, 0, 0);
        SwitchThiny();
        FollowMouse();
        Vector3 mousePosition = Input.mousePosition;
        if(graphic!= null)
        {
            if (gameObject.transform.rotation.z > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        
    }
    void FollowMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }
    void ShootingBullet()
    {

    }
    private void SwitchThiny()
    {
        if (thiny != PlayerManager.instance.player )
        {
            PlayerManager.instance.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            0f);
            //thiny.currentHp = HealthSystem.instance.HpPlayer;
            Destroy(graphic);
            Destroy(gameObject);
        }
        else if (thiny.isDied)
        {
            GameObject r = Instantiate(reserve, transform.position, Quaternion.identity, PlayerManager.instance.transform);
            SwapThiny.instance.call = true;
            PlayerManager.instance.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            0f);
            Destroy(graphic);
            Destroy(gameObject);
        }

    }
}
