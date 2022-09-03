﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{


    public int damageAmount = 2;
    public LayerMask playerLayer;



    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position,0.1f,playerLayer);

        if (hits.Length > 0)
        {
            if (hits[0].gameObject.tag == MyTags.PLAYER_TAG)
            {

                hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);
            }
        }

    }
    // Start is called before the first frame update
   
}
