using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenshiSlash : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Start()
    {
        if (Kenshi.instance != null)
        {
            player = GameObject.FindWithTag("Player");
        }

    }
    private void Update()
    {
        if ((player.gameObject != null) && (Kenshi.instance != null)) //ป้องกัน kibby ถูกทำลาย "ถ้า kibby ถูกทำลาย void update จะไม่ทำงาน"
        {
            transform.position = new(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }
    void DestroyWave()
    {
        Kenshi.instance.isAttack = false;
        Destroy(gameObject);
    }
}
