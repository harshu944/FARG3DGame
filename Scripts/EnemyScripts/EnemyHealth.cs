using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private EnemyScript enemyScript;

    private Animator anim;


    void Awake()
    {
        enemyScript = GetComponent<EnemyScript>();
        anim = GetComponent<Animator>();
    }



    public void ApplyDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            health = 0;
            //DISPLAY THE HEALTH VALUE


        }
        if (health == 0)
        {
            enemyScript.enabled = false;
            anim.SetTrigger(MyTags.DEAD_TRIGGER);
            Invoke("DeactiveEnemy", 3f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void DeactiveEnemy()
    {
        gameObject.SetActive(false);
    }

}
