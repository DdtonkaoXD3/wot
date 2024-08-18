using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    AudioSource au;
    
    [SerializeField] AudioClip ac;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            au.PlayOneShot(ac);
            ResourceSystem.instance.receiveCoin();
            Destroy(gameObject);
        }
    }
}
