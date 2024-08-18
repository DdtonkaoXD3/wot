using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "x" + ResourceSystem.instance.coin;
    }
}
