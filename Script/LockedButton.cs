using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockedButton : MonoBehaviour
{
    [SerializeField] private int condition;
    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceSystem.instance.chapter >= condition)
        {
            button.interactable = true;

        }
        else
        {
            button.interactable = false;
        }
    }
}
