using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public Skill CurrentActiveSkill; //{ get; private set; }
    private PlayerControls playerControls;
    private float timeBetweenAttacks;
    public static ActiveSkill instance;
    private bool attackButtonDown, isAttacking = false;
    void Awake()
    {
        instance = this;
        playerControls = new PlayerControls();
    }

    private void
    OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
    public void WeaponNull()
    {
        CurrentActiveSkill = null;
    }

}
