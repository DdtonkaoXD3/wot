using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blouder : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    [SerializeField] private Skill bomb;
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint, rotationBullet;
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
        arrowSpawnPoint = GameObject.Find("Gun").transform;
        rotationBullet = GameObject.Find("RotationBullet").transform;
        if (ManaSystem.instance.MpPlayer >= bomb.manaCost && !bomb.isUsing)
        {
            GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, rotationBullet.transform.rotation);
            bomb.InteractSkill();
        }

    }
}
