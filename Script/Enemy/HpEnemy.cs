using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Hitpoints;
    public float MaxHitpoints;
    public float endlessBuff=0;
    //[SerializeField] private EnemyThiny enemy;
    Animator animator;
    [SerializeField] HpBarEnemy hpBar;
    public static HpEnemy instance;
    public bool death = false;
    public bool resistanceKnockback = false;
    private bool doDamage=true;
    public bool receiveDamage=true;
    //Flash flash;
    KnockbackedEnemy knockback;
    EnemyMovement enemyMovement;
    EnemySearchComponent enemy;
    Animator anim;
    [SerializeField]AudioClip hit;
    AudioSource au;

    private void Awake()
    {
        
        knockback = GetComponent<KnockbackedEnemy>();
        instance = this;
    }
    void Start()
    {
        au = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemySearchComponent>();
        Hitpoints = enemy.type.hp + endlessBuff;
        MaxHitpoints = Hitpoints;
        SpawnThiny.instance.ThinyCount++;
        enemyMovement = GetComponent<EnemyMovement>();
        //flash = GetComponent<Flash>();
        animator = GetComponent<Animator>();
        
        hpBar = GetComponentInChildren<HpBarEnemy>();
        hpBar.UpdateHealthBar(Hitpoints, MaxHitpoints);
        //HpBar.SetHealth(Hitpoints, MaxHitpoints);
    }
    private void Update()
    {
        hpBar.UpdateHealthBar(Hitpoints, MaxHitpoints);

        if (Kenshi.instance != null)
        {
            if (!Kenshi.instance.isAttack)
            {
                receiveDamage = true;
            }
        }
        if (Kibby.instance != null)
        {
            if (!Kibby.instance.isAttack)
            {
                receiveDamage = true;
            }
        }

        if (Hitpoints <= 0 && !death)
        {
            SpawnThiny.instance.ThinyCount--;
            enemyMovement.enabled = false;
            animator.SetTrigger("death");
            if(GameController.instance != null)
            {
                GameController.instance.GetScore(enemy.type);
            }
            death = true;
            if (Endless.instance != null)
            {
                Endless.instance.score += 10;
            }
            Destroy(gameObject);
            //StartCoroutine(CooldownDestroy());
        }
    }
    public void TakeHit(float damage, Elemental elemental)
    {
        Color32 colorText;
        damage = PlayerManager.instance.player.Critical(damage);
        damage = enemy.type.elemental.AnalyzeDamage(damage, elemental);
        if (damage <= enemy.type.def)
        {
            damage = 1f;
        }
        else
        {
            damage -= enemy.type.def;
            damage = Mathf.Max(1, damage);
        }
        if (PlayerManager.instance.player.cri)
        {
            colorText = new Color32(255, 0, 0, 255);
        }
        else
        {
            colorText = enemy.type.elemental.Color(elemental);
        }
        
        AtkTextController.instance.showDamageText(PlayerManager.instance.player.cri, damage, gameObject.transform, colorText);
        Hitpoints -= damage;
        if (!resistanceKnockback && PlayerMovement.instance != null)
        {
            knockback.GetKnockedBack(PlayerMovement.instance.transform, 15f);
        }
       //StartCoroutine(flash.FlashRoutine());
       
        //HpBar.SetHealth(Hitpoints, MaxHitpoints);

    }
    IEnumerator CooldownDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    IEnumerator DoDamage()
    {
        anim.SetBool("Melee", true);
        yield return new WaitForSeconds(0.5f);
        au.PlayOneShot(hit);
        doDamage = true;
        anim.SetBool("Melee", false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeHit(PlayerManager.instance.damage, PlayerManager.instance.player.elemental);
            au.PlayOneShot(hit);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Skill")
        {
            SkillDamage otherSkill = other.GetComponent<SkillDamage>();
            Skill skill = otherSkill.skillInfo();
            TakeHit(skill.SkillDamage(), skill.elemental);
            au.PlayOneShot(hit);
            Destroy(other.gameObject);  
        }
        if (other.gameObject.tag == "SkillArea")
        {
            SkillDamage otherSkill = other.GetComponent<SkillDamage>();
            Skill skill = otherSkill.skillInfo();
            TakeHit(skill.SkillDamage(), skill.elemental);
            au.PlayOneShot(hit);
            receiveDamage = false;
        }

        if (other.gameObject.tag == "MeleeAttack" && receiveDamage)
        {
            au.PlayOneShot(hit);
            receiveDamage = false;
            TakeHit(PlayerManager.instance.damage, PlayerManager.instance.player.elemental);
            
        }
        if(other.gameObject.tag == "Bullet")
        {
            au.PlayOneShot(hit);
            Destroy(other.gameObject);
        }
        if(other.gameObject.name == "Dr.Flask" && doDamage)
        {
            Flask.instance.FlaskGetDamage(enemy.type.atk);
            doDamage = false;
            StartCoroutine(DoDamage());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && doDamage)
        {
            HealthSystem.instance.AttackedPlayer(enemy.type.atk, enemy.type.elemental);
            doDamage = false;
            StartCoroutine(DoDamage());
        }
    }
}
