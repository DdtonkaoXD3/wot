using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    [SerializeField] List<GameObject> waypoints;
    [SerializeField] float speed = 1f;
    [SerializeField] int index=0;
    [SerializeField] private float HpMax = 100f;
    [SerializeField] private float HpCurrent;
    HpBarEnemy hpbar;
    public static Flask instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        HpCurrent = HpMax;
        hpbar = GetComponentInChildren<HpBarEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);
        if(index < waypoints.Count - 1 && (distance <= 0.05f))
        {
            index++;
        }
        if (HpCurrent <= 0)
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }
    public void FlaskGetDamage(float damage)
    {
        HpCurrent -= damage;
        hpbar.UpdateHealthBar(HpCurrent, HpMax);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Finish Line")
        {
            GameController.instance.currentProtect++;
        }
    }
}
