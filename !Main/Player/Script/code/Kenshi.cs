using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenshi : MonoBehaviour
{
    // Start is called before the first frame

    [SerializeField] private PlayerThiny thiny;
    public GameObject arrowPrefab;
    [SerializeField] private GameObject arrowSpawnPoint, player, rotationBullet;
    Vector3 offset = new Vector3(0, 0, 90f);
    private float nextShoot = 0f;
    private float TimeCooldown = 0.5f;
    public bool isAttack = false;
    public static Kenshi instance;
    public GameObject graphic;
    [SerializeField] Animator anim;
    public SpriteRenderer sr;
   //public GameObject reserve;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TimeCooldown = thiny.atkSpeed;
    }
    private void Update()
    {
        //transform.localPosition = new Vector3(0, 0, 0);
        Vector3 offset = Vector3.zero;
        FollowMouse();
        nextShoot += Time.deltaTime;
        if (graphic != null)
        {
            if (gameObject.transform.rotation.z > 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
        if (Input.GetMouseButton(0) && nextShoot >= TimeCooldown)
        {
            //offset = player.transform.rotation + offset;
            anim.SetBool("Attack", true);

            isAttack = true;
            
            nextShoot = 0f;
            StartCoroutine(endAnimation());

        }

        SwitchThiny();
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
        if (thiny != PlayerManager.instance.player)
        {
            PlayerManager.instance.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            0f);
            //hiny.currentHp = HealthSystem.instance.HpPlayer;
            //thiny.currentMp = ManaSystem.instance.MpPlayer;
            Destroy(graphic);
            Destroy(gameObject);
        }
        else if (thiny.isDied)
        {
            //GameObject r = Instantiate(reserve, transform.position, Quaternion.identity, PlayerManager.instance.transform);
            SwapThiny.instance.call = true;
            PlayerManager.instance.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            0f);
            Destroy(graphic);
            Destroy(gameObject);
        }

    }
    IEnumerator endAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform.position, rotationBullet.transform.rotation);
        anim.SetBool("Attack", false);
    }
}
