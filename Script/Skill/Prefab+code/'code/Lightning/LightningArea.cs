using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightningPrefab;
    public List<GameObject> enemies = new List<GameObject>();
    //public Vector3 offset= new Vector3(0,1.25f,0);

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyThunder()
    {
        HpEnemy.instance.receiveDamage=true;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject lightning = Instantiate(lightningPrefab, collision.transform.position/*+ offset*/, Quaternion.Euler(new Vector3(0, 0, 0)), collision.transform);
        }
    }
}
