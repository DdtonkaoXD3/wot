using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Elemental", menuName = "Elemental")]
public class Elemental : ScriptableObject
{
    public new string name;
    public Sprite elementalLogo;
    public List<Elemental> strength = new List<Elemental>(); //ถูกโจมตีจากธาตุที่ชนะทาง
    public List<Elemental> weakness = new List<Elemental>(); //ถูกโจมตีจากธาตุที่แพ้ทาง
    public Color32 elementalColor;
    public Color32 colorText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float AnalyzeDamage(float damage, Elemental elemental)
    {
        for(int i=0; i<weakness.Count; i++)
        {
            if(elemental == weakness[i])
            {
                damage = damage * 2;
            }
        }
        for (int j = 0; j < strength.Count; j++)
        {
            if (elemental == strength[j])
            {
                damage = damage * 0.5f;
            }
        }
        return damage;
    }
    public Color32 Color(Elemental elemental)
    {
        colorText = new Color32(255, 255, 255, 255);
        for (int i = 0; i < weakness.Count; i++)
        {
            if (elemental == weakness[i])
            {
                colorText = new Color32(255, 255, 0, 255);
            }
        }
        for (int j = 0; j < strength.Count; j++)
        {
            if (elemental == strength[j])
            {
                colorText = new Color32(47, 79, 79, 255);
            }
        }
        return colorText;
    }
}
