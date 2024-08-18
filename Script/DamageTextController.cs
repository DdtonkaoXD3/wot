using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageTextController : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public string textToDisplay,showText;
    public static DamageTextController instance;
    public GameObject enemy;
    public TextMeshPro dt;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
    }
    public void showDamageText(bool cri, float damage, Transform Thiny, Color32 colortext)
    {
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, Thiny.transform.position , Quaternion.identity);
        if (!cri)
        {
            showText = textToDisplay + damage.ToString();
        }
        else
        {
            showText = "Critical";
        }
            
        TextMeshPro dt = DamageTextInstance.GetComponentInChildren<TextMeshPro>();
        dt.color = colortext;
        dt.SetText(showText);
    }
}
