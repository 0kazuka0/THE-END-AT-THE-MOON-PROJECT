using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymelee1 : MonoBehaviour
{
    [Header("speedmove")]
    [SerializeField] private float enemyspeed;
   
     Animator enemyanimator;
    [Header("facing")]
    [SerializeField] private GameObject enemygraphic;
    bool canflip = true;
    bool facingright = false;
    float fliptime = 5f;
    float nextflipchance = 0f;

    [Header("attacking")]
    [SerializeField] private float chargetime;
    float startchargetime;
    bool charging;
    Rigidbody2D enemyRB;


    public static AudioClip melee1atk; //sound
    static AudioSource soundsorce;
    // Start is called before the first frame update
    void Start()
    {
        enemyanimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();

        melee1atk = Resources.Load<AudioClip>("melee1atk");

        soundsorce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>nextflipchance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                flipFacing();
                nextflipchance = Time.time + fliptime;
            }
        }
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(facingright&&collision.transform.position.x<transform.position.x)
            {
                flipFacing();

            }
            else if(!facingright && collision.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canflip = false;
            charging = true;
            startchargetime = Time.time + chargetime;
            if(charging==true)
            {
                soundsorce.PlayOneShot(melee1atk);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           if(startchargetime<Time.time)
            {
                if (!facingright)
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemyspeed);
                    enemyanimator.SetBool("isCharging", charging);
                }
                else
                {
                    enemyRB.AddForce(new Vector2(1, 0) * enemyspeed);
                    enemyanimator.SetBool("isCharging", charging);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            canflip = true;
            charging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyanimator.SetBool("isCharging", charging);
        }
    }
    void flipFacing()
    {
        if (!canflip) return;
        float facingX = enemygraphic.transform.localScale.x;
        facingX *= -1f;
        enemygraphic.transform.localScale = new Vector3(facingX, enemygraphic.transform.localScale.y, enemygraphic.transform.localScale.z);
        facingright = !facingright;
        
    }
}
