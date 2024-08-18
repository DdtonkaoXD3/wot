using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    private void Start()
    {

    }
    public void DestroyParent()
    {
        Destroy(parent);
    }
}
