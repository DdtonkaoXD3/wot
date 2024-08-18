using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBuff : MonoBehaviour,ISkill
{
    // Start is called before the first frame update
    public Skill skill;
    public GameObject[] enemies;
    public GameObject BuffPrefab;
    public GameObject buff,player;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.gameObject != null) && buff.gameObject != null) //ป้องกัน kibby ถูกทำลาย "ถ้า kibby ถูกทำลาย void update จะไม่ทำงาน"
        {
           
                buff.transform.position = new(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            
        }
        else
        {
            

        }
    }

    public void UseSkill()
    {
        if (ManaSystem.instance.MpPlayer >= skill.manaCost && (!skill.isUsing))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.AddComponent<StickyBuffPlayer>();
            buff = Instantiate(BuffPrefab, player.transform.position, Quaternion.identity , player.transform);
            skill.InteractSkill();
            skill.isCooldown = false;
            player = GameObject.FindWithTag("Player");
        }
        
    }

}
