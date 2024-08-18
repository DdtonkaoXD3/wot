using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonLockThiny : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button button;
    [SerializeField] PlayerThiny thiny;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thiny.isHaving)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
