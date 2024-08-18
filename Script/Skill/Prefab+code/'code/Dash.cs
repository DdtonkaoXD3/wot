using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour, ISkill
{
    // Start is called before the first frame update
    [SerializeField]
    private Skill dash;
    [SerializeField]
    private float dashSpeed = 3f;
    private float timing;
    public static Dash instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    // Update is called once per frame

    public void UseSkill()
    {
        if (ManaSystem.instance.MpPlayer >= dash.manaCost && !dash.isUsing)
        {
            dash.InteractSkill();
            StartCoroutine(EndDashRoutine());
        }
        
    }
    IEnumerator EndDashRoutine()
    {
        PlayerManager.instance.Speed *= dashSpeed;
        yield return new WaitForSeconds(0.2f);
        float dashTime = 0.2f;
        yield return new WaitForSeconds(dashTime);
        PlayerManager.instance.Speed /= dashSpeed;

    }
}
