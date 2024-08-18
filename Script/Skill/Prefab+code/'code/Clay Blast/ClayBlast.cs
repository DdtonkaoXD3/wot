using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClayBlast : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    [SerializeField] private Skill skill;
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject clayBlast;
    [SerializeField] private Transform arrowSpawnPoint, rotationBullet;
    [SerializeField] private float nextShoot;
    [SerializeField] private float TimeCooldown = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill()
    {
        arrowSpawnPoint = GameObject.Find("Gun").transform;
        rotationBullet = GameObject.Find("RotationBullet").transform;
        if (ManaSystem.instance.MpPlayer >= skill.manaCost && !skill.isUsing)
        {
            GameObject newArrow = Instantiate(clayBlast, arrowSpawnPoint.position, rotationBullet.transform.rotation);
            skill.InteractSkill();
        }

    }
}
