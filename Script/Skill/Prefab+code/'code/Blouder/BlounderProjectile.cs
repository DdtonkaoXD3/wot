using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlounderProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject effect;
    float timeDestroy;
    private void Start()
    {

    }
    private void Update()
    {
        timeDestroy += Time.deltaTime;
        if (timeDestroy >= 3f)
        {
            Destroy(this.gameObject);
        }
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.GetComponent<BlounderStunEnemy>() == null)
        {
            collision.gameObject.AddComponent<BlounderStunEnemy>();
            GameObject lightning = Instantiate(effect, collision.transform.position/*+ offset*/, Quaternion.Euler(new Vector3(0, 0, 0)), collision.transform);
        }
            
    }
}
