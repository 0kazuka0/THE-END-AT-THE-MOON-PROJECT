using UnityEngine;

public class EnemyProjectile : EnemyRangeDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    private Animator anim;
    private BoxCollider2D coll;
    
    public GameObject hitfx;
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //hit = true;
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        if(collision.tag=="Player")
        {
            gameObject.SetActive(false);
            Instantiate(hitfx, transform.position, transform.rotation);
        }
        //coll.enabled = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}