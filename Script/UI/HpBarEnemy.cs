using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform cameraa;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private void Start()
    {
        /*if (slider == null)  //ถ้า targetObject เป็นค่าว่าง ให้...
        {
            slider = GameObject.FindGameObjectsWithTag("HpBar").GetComponent<Slider>();
        }*/
        if (cameraa == null)  //ถ้า targetObject เป็นค่าว่าง ให้...
        {
            cameraa = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cameraa.transform.rotation;
        transform.position = target.position + offset;
    }
}
