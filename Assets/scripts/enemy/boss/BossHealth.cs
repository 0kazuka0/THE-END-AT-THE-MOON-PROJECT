using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public float health = 100;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public void takedmg(float damage)
	{
		if (isInvulnerable)
			return;
		//เสียงbossโดน dmg
		SFX2.playsound("melee1hit");
		health -= damage;

		if (health <= 50)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
	public void pslife1()
    {
		SFX.playsound("bossintro");
    }
	public void pslife2()
	{
		SFX.playsound("bossintro2");
	}

}
