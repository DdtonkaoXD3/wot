using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reserve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!GameController.instance.gameOver)
        {
            StartCoroutine(destroyRe());
        }*/
    }
    IEnumerator destroyRe()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        
    }
}
