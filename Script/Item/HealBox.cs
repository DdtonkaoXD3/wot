using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] AudioClip ac;
    AudioSource au;
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
        if(collision.gameObject.tag == "Player")
        {
            HealthSystem.instance.HealPlayer(20f);
            au.PlayOneShot(ac);
            Destroy(gameObject);
        }
    }
}
