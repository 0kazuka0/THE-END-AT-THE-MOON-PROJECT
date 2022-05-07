using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [Header("playerspeed")]
    //movement section
    public float runspeed;
    [Header("playerjump")]
    //jump section
    bool grounded = false;
    float groundcheckradius = 0.2f;
    public LayerMask groundlayer;
    public Transform groundcheck;
    public float jumpheight;

    Rigidbody2D rb;
    Animator anim;
    bool facingright;

    

    [Header("shooting pistol section")]
    //shooting pistol section 
    public Transform guntip;
    public GameObject bullet;
    public GameObject muzzleflash;
    [SerializeField] private int frametoflash=1;
    bool isflashing = false;
    [SerializeField] private float firerate = 0.5f;
    float nextfire = 0f;

    [Header("shooting smg section")]
    public Transform guntip2;
    public GameObject bullet2;
    [SerializeField] private float firerate2 = 0.2f;
    [SerializeField] private float nextfire2 = 0f;

    [Header("shooting laser section")]
    public Transform guntip3;
    public GameObject bullet3;
    [SerializeField] private float firerate3 = 0.5f;
    [SerializeField] private float nextfire3 = 0f;

    [Header("shooting rpg section")]
    public Transform guntip4;
    public GameObject bullet4;
    [SerializeField] private float firerate4 = 0.5f;
    [SerializeField] private float nextfire4 = 0f;

    public static AudioClip pistol,laser,rocket;
    static AudioSource soundsorce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(muzzleflash!=null)
        {
            muzzleflash.SetActive(false);
        }
        //muzzleflash.transform.localScale = new Vector2(-1, 0);
        facingright = true;

        pistol = Resources.Load<AudioClip>("pistol");
        laser = Resources.Load<AudioClip>("laser");
        rocket = Resources.Load<AudioClip>("rocket");
        soundsorce = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(grounded&&Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            anim.SetBool("isGrounded", grounded);
            rb.AddForce(new Vector2(0, jumpheight));
        }
        //player shoot input
        if(Input.GetKey(KeyCode.Z)&&gamevalue.weapon==1&&grounded==true)
        {
            anim.SetTrigger("attack");
            firebullet();
            if (muzzleflash != null && !isflashing)
            {
                StartCoroutine(Doflash());
            }
        }
        if (Input.GetKey(KeyCode.Z) && gamevalue.weapon == 2&&grounded==true)
        {
            anim.SetTrigger("attack");
            firebullet2();
            if (muzzleflash != null && !isflashing)
            {
                StartCoroutine(Doflash());
            }
        }
        if (Input.GetKey(KeyCode.Z) && gamevalue.weapon == 3&&grounded==true)
        {
            anim.SetTrigger("attack");
            firebullet3();
        }
        if (Input.GetKey(KeyCode.Z) && gamevalue.weapon == 4&&grounded==true)
        {
            anim.SetTrigger("attack");
            firebullet4();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //check grounded
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, groundlayer);
        anim.SetBool("isGrounded", grounded);

        anim.SetFloat("VerticalSpeed", rb.velocity.y);


        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * runspeed, rb.velocity.y);

        if(move>0&&!facingright)
        {
            flip();
        }
        else if(move<0&&facingright)
        {
            flip();
        }
    }
    void flip()
    {
        facingright = !facingright;
        Vector3 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }
    //bullet shoot spawn
    void firebullet()//pistol
    {
        if(Time.time>nextfire)
        {
            nextfire = Time.time + firerate;
            if (facingright)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                soundsorce.PlayOneShot(pistol);
                if (muzzleflash != null && !isflashing)
                {
                    StartCoroutine(Doflash());
                }
            }
            else if (!facingright)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                soundsorce.PlayOneShot(pistol);
            }
            
        }
    }
    void firebullet2()//smg
    {
        if (Time.time > nextfire2)
        {
            nextfire2 = Time.time + firerate2;
            if (facingright)
            {
                soundsorce.PlayOneShot(pistol);
                Instantiate(bullet2, guntip2.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                if (muzzleflash != null && !isflashing)
                {
                    StartCoroutine(Doflash());
                }
            }
            else if (!facingright)
            {
                Instantiate(bullet2, guntip2.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                soundsorce.PlayOneShot(pistol);
            }

        }
    }
    void firebullet3()//laser
    {
        if (Time.time > nextfire3)
        {
            nextfire3 = Time.time + firerate3;
            if (facingright)
            {
                soundsorce.PlayOneShot(laser);
                Instantiate(bullet3, guntip3.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingright)
            {
                Instantiate(bullet3, guntip3.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                soundsorce.PlayOneShot(laser);
            }

        }
    }
    void firebullet4()//rpg
    {
        if (Time.time > nextfire4)
        {
            nextfire4 = Time.time + firerate4;
            if (facingright)
            {
                soundsorce.PlayOneShot(rocket);
                Instantiate(bullet4, guntip4.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingright)
            {
                Instantiate(bullet4, guntip4.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                soundsorce.PlayOneShot(rocket);
            }

        }
    }

    IEnumerator Doflash()
    {
        muzzleflash.SetActive(true);
        var frameflashed = 0;
        isflashing = true;
        while(frameflashed<=frametoflash)
        {
            frameflashed++;
            yield return null;
        }
        muzzleflash.SetActive(false);
        isflashing = false;
    }
}
