using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShield : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    public Skill skill;
    public GameObject BuffPrefab;
    public GameObject buff, player;
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
            if (GameObject.FindWithTag("Player") != null)
            {
                skill.isCooldown = false;
                skill.InteractSkill();
                buff = Instantiate(BuffPrefab, player.transform.position, Quaternion.identity, player.transform);
                HealthSystem.instance.IncreaseDef += 20f;
                StartCoroutine(timeSkill());
            }

        }

    }
    IEnumerator timeSkill()
    {
        yield return new WaitForSeconds(6f);
        skill.isCooldown = true;
        HealthSystem.instance.IncreaseDef = 0;
        Destroy(buff);
    }
}
