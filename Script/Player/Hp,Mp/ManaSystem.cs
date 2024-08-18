using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaSystem : MonoBehaviour
{
    public static ManaSystem instance;
    public float MpPlayer = 100f;
    public Image MpBar;
    public Text textMp;
    public float MpPlayerMax;
    void Start()
    {
        MpPlayerMax = MpPlayer;
        InvokeRepeating("IncreaseMP", 0.5f, 2f);
    }

    // Update is called once per frame
    void IncreaseMP()
    {
        MpPlayer += 10f;
    }


    private void Awake()
    {
        instance = this;
    }
    public void UseMana(float useMana)
    {
        MpPlayer = MpPlayer - useMana;

    }

    // Update is called once per frame
    void Update()
    {
        if (MpPlayer >= MpPlayerMax)
        {
            MpPlayer = MpPlayerMax;
        }
        if (MpPlayer <= 0f)
        {
            MpPlayer = 0f;
        }
        float radio = MpPlayer / MpPlayerMax;
        MpBar.rectTransform.localScale = new Vector3(radio, 1, 1);
        float percentHp = radio * 100;
        textMp.text = System.Math.Round(percentHp, 0) + " %";
    }
}
