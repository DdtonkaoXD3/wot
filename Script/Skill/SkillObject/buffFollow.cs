using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject player;
    private void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }

    }
    private void Update()
    {
        if (GameObject.FindWithTag("Player") != null) //ป้องกัน kibby ถูกทำลาย "ถ้า kibby ถูกทำลาย void update จะไม่ทำงาน"
        {
            transform.position = new(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }
}
