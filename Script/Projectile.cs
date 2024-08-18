using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float moveSpeed = 22f;
    float timeDestroy;
    private void Start()
    {
        
    }
    private void Update()
    {
        timeDestroy += Time.deltaTime;
        if(timeDestroy >= 3f)
        {
            Destroy(this.gameObject);
        }
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
