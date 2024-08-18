using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingArea : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text text;
    [SerializeField] private float waitTime=20f;
    [SerializeField] private float timeScore;
    [SerializeField] private bool check=false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        text = GameObject.Find("AreaCooldown").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            timeScore += Time.deltaTime;
            text.enabled = true;
            text.text = string.Format("{0:F1}", timeScore) + " s / 20s";
        }
        
        
        if (timeScore >= waitTime)
        {
            text.enabled = false;
            GameController.instance.currentArea++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            check = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check = false;
        }
    }
}
