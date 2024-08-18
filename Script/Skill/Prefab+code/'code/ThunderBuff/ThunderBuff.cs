using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBuff : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    public Skill skill;
    public GameObject BuffPrefab;
    public GameObject buff,player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill()
    {
        if (ManaSystem.instance.MpPlayer >= skill.manaCost && (!skill.isUsing))
        {
            if(GameObject.FindWithTag("Player") != null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                skill.isCooldown = false;
                skill.InteractSkill();
                buff = Instantiate(BuffPrefab, player.transform.position, Quaternion.identity, player.transform);
                PlayerManager.instance.damage = (PlayerManager.instance.player.atk * 1.5f);
                StartCoroutine(timeSkill());
            }            
        }

    }
    IEnumerator timeSkill()
    {
        yield return new WaitForSeconds(7f);
        skill.isCooldown = true;
        PlayerManager.instance.damage = PlayerManager.instance.player.atk;
        Destroy(buff);
    }
}
