using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int beta = 1;
    public static GameObject player;
    public static GameObject arrowPrefab;
    public static Transform arrowSpawnPoint, rotationBullet;
    Vector3 offset = new Vector3(0, 0, 90f);
    public static float nextShoot = 0f;
    public static float TimeCooldown = 0.5f;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public static void SetBullet(PlayerThiny thiny)
    {
        TimeCooldown=thiny.atkSpeed;
    }
    public static void TypeAttack(PlayerThiny thiny, bool isRange)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = new Vector3(mousePosition.x - player.transform.position.x, mousePosition.y - player.transform.position.y);
        player.transform.up = direction;
    }
    public static void ShootingBullet()
    { 
         nextShoot += Time.deltaTime;
         if (Input.GetMouseButton(0) && nextShoot >= TimeCooldown)
         {
            //offset = player.transform.rotation + offset;
            GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, rotationBullet.transform.rotation);
            MonoBehaviour g =newArrow.GetComponent<MonoBehaviour>();
            nextShoot = 0f;
            
         }
    }
}
