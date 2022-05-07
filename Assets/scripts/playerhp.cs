using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerhp : MonoBehaviour
{
    public float fullhp;
    //public GameObject deathfx;

    float currenthp;

    bool death;

    playercontroller controlmovement;

    private Animator anim;

    public static AudioClip hit, die;
    static AudioSource soundsorce;

    

    //HUD variables
    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("hit");
        die = Resources.Load<AudioClip>("die");
        soundsorce = GetComponent<AudioSource>();

        currenthp = fullhp;
        controlmovement = GetComponent<playercontroller>();

        healthslider.maxValue = fullhp;
        healthslider.value = fullhp;

        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void takedmg(float damage)
    {
        if (damage <= 0) return;
        currenthp -= damage;
        soundsorce.PlayOneShot(hit);
        healthslider.value = currenthp;

        if(currenthp<=0)
        {
            //dead();// no use
            if (!death)
            {
                anim.SetTrigger("die");
                soundsorce.PlayOneShot(die);
                controlmovement.enabled = false;
                death = true;
            }
        }
    }
    public void addhp(float healthamount)
    {
        currenthp += healthamount;
        if (currenthp > fullhp) currenthp = fullhp;
        healthslider.value = currenthp;
    }
    public void dead()
    {
        //Instantiate(deathfx, transform.position, transform.rotation);
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
