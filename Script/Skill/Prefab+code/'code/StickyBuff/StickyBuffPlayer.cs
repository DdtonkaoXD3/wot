using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBuffPlayer : MonoBehaviour
{
    [SerializeField] Skill skill;
    [SerializeField] GameObject buff;
    GameObject[] arrowPrefab,meleePrefab;
    StickyBuff that;
    [SerializeField] GameObject player;
    void Start()
    {
        that = GameObject.Find("StickyBuff(Clone)").GetComponent<StickyBuff>();
        buff = GameObject.Find("StickyAuraBuff(Clone)");
        that.skill.isUsing = true;
      


    }

    // Update is called once per frame
    void Update()
    { 
       
    
        arrowPrefab = GameObject.FindGameObjectsWithTag("Bullet");
        meleePrefab = GameObject.FindGameObjectsWithTag("MeleeAttack");
        foreach (GameObject prefab in arrowPrefab) {
            prefab.AddComponent<StickyBuffArrow>();
        }
        foreach (GameObject prefab in meleePrefab)
        {
            prefab.AddComponent<StickyBuffArrow>();
        }

        StartCoroutine(destroyThis());
    }
    IEnumerator destroyThis()
    {
        yield return new WaitForSeconds(10f);
        that.skill.isCooldown = true;
        Destroy(buff);
        Destroy(this);
    }
}
