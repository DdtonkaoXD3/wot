using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint, rotationBullet;
    Vector3 offset = new Vector3(0, 0, 90f);
    [SerializeField] private float nextShoot=0f;
    [SerializeField] private float TimeCooldown =0.5f;
    //[SerializeField] private GameObject graphic;
    [SerializeField] Animator anim;
    private void Start()
    {
        
    }
    IEnumerator finishAnim()
    {
        FhunG.instance.FhunAttack(true);
        yield return new WaitForSeconds(0.3f);
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, rotationBullet.transform.rotation);
        FhunG.instance.FhunAttack(false);
        

    }
    private void Update()
    {
        nextShoot += Time.deltaTime;
        if (Input.GetMouseButton(0) && nextShoot >= TimeCooldown)
        {
            //offset = player.transform.rotation + offset;
            
            nextShoot = 0f;
            StartCoroutine(finishAnim());
            
            
        }
    }

}
