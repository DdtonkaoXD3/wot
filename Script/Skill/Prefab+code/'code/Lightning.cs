using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField] private Skill skill;
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private Transform player;
    Vector3 offset = new Vector3(0, 0, 90f);
    [SerializeField] private float nextShoot;
    [SerializeField] private float TimeCooldown = 0.5f;
    private void Start()
    {

        /*
        arrowSpawnPoint = GameObject.Find("Gun").transform;
        rotationBullet = GameObject.Find("RotationBullet").transform;*/

    }
    public void UseSkill()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (ManaSystem.instance.MpPlayer >= skill.manaCost && !skill.isUsing)
        {
            GameObject newArrow = Instantiate(lightningPrefab, player.position, player.transform.rotation, player.transform);
            skill.InteractSkill();
        }

    }
}
