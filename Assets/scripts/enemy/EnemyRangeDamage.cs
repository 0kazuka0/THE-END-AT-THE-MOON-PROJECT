using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeDamage : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<playerhp>().takedmg(damage);
    }
}
