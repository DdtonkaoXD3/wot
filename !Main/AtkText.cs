using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkText : MonoBehaviour
{
    public GameObject parent;
    void DestroyParent(){
        Destroy(parent);
    }
}
