using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kibby : MonoBehaviour
{
    private int beta = 1;
    [SerializeField] private PlayerThiny thiny;
    public GameObject arrowPrefab;
    [SerializeField] private GameObject point,arrowSpawnPoint, player;
    Vector3 offset = new Vector3(0, 0, 90f);
    private float nextShoot = 0f;
    private float TimeCooldown = 0.5f;
    public bool isAttack=false;
    public static Kibby instance;
    public GameObject reserve;
    public GameObject graphic;
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
        if(point.transform.rotation.z < 0)
        {
            graphic.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            graphic.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
        nextShoot += Time.deltaTime;
        if (Input.GetMouseButton(0) && nextShoot >= TimeCooldown)
        {
            //offset = player.transform.rotation + offset;
            isAttack = true;
            GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform.position, Quaternion.identity); ;//Quaternion.Euler(offset.x,offset.y,offset.z)); ;
            nextShoot = 0f;


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

}
