using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector3 offset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = offset;
    }
}
