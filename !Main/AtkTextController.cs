using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtkTextController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject damageTextPrefab;
    public string textToDisplay;
    public static AtkTextController instance;
    //public GameObject enemy;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.X)){ 
            GameObject DamageTextInstance = Instantiate(damageTextPrefab, enemy.transform.position, Quaternion.identity);
            Text dt = DamageTextInstance.GetComponentInChildren<Text>();
            dt.text = "test";
        }*/
    }
    public void showDamageText(bool cri , float damage, Transform Thiny, Color32 colorText)
    {
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, Thiny.transform.position, Quaternion.identity);
        Text dt = DamageTextInstance.GetComponentInChildren<Text>();
        if (!cri) {
            dt.text = damage.ToString();
            dt.color = colorText;
        }
        else
        {
            dt.text = "Critical";
            dt.color = colorText; 
        }
       
        
    }
}
