using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;
    public float HpPlayer;
    public Image HpBar;
    public Text textHp;
    public float HpPlayerMax;
    public float IncreaseDef=0f;
    PlayerManager manager;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        manager = PlayerManager.instance;
        HpPlayer = manager.player.hp;
        HpPlayerMax = manager.player.hp;
    }
    public void AttackedPlayer(float damage, Elemental elemental)
    {
        damage = manager.player.elemental.AnalyzeDamage(damage, elemental);
        if (damage <= manager.player.def)
        {
            damage = 1f;
        }
        else
        {
            damage -= (manager.player.def+IncreaseDef);
            damage = Mathf.Max(1, damage);
        }
        HpPlayer -= damage;
        Color32 colorText = manager.player.elemental.Color(elemental);
        AtkTextController.instance.showDamageText(false,damage, GameObject.FindWithTag("Player").transform, colorText);
        HpPlayer = HpPlayer - damage;
    }
    public void HealPlayer(float heal)
    {
        HpPlayer += heal;
    }
    // Update is called once per frame
    void Update()
    {
        if (HpPlayer >= HpPlayerMax)
        {
            HpPlayer = HpPlayerMax;
        }
        if (HpPlayer <= 0f && !GodMode.instance.Immortal)
        {
            HpPlayer = 0f;
            PlayerManager.instance.player.isDied = true;
            SwapThiny.instance.call = true;
        }
        HpPlayer = System.Math.Max(HpPlayer, 0f);
        float radio = HpPlayer / HpPlayerMax;
        HpBar.rectTransform.localScale = new Vector3(radio, 1, 1);
        float percentHp = radio * 100;
        textHp.text = System.Math.Round(percentHp, 0) + " %";
    }
    public void gay()
    {

    }
}
