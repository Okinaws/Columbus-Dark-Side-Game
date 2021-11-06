using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject player;
    private Vector2 enemyPos;
    public Transform punchPoint;
    public LayerMask Protagonist;
    public Hp hp;
    public GameObject coin;
    public GameObject heart;

    public float speed = 4.5f;

    public float vision = 10f;

    private float punchRadius = 0.4f;
    private bool hitCD = false;

    private bool faceRight = false;

    private bool coinDrop = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        GameObject[] drops = { coin, heart };
    }

    void Update()
    {
        if (faceRight && transform.position.x > player.transform.position.x)
        {
            Flip();
        }
        else if (!faceRight && transform.position.x < player.transform.position.x)
        {
            Flip();
        }

        if (Math.Abs(player.transform.position.x - transform.position.x) < vision && Math.Abs(player.transform.position.y - transform.position.y) < vision)
        {
            Fight();
        }
        else
        {
            Calm();
        }

    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void Fight()
    {
        if (hp.HP <= 0)
        {
            if (!coinDrop)
            {
                coinDrop = true;
                Invoke("SpawnDrop", 0.45f);
            }
            anim.SetTrigger("Death");
        }
        else if (Physics2D.OverlapCircle(punchPoint.position, punchRadius, Protagonist) && !hitCD)
        {
            hitCD = true;
            anim.SetTrigger("Attack");
            Invoke("Attack", 0.4f);
            Invoke("StopAttack", 0.8f);
        }
        else if (!hitCD)
        {
            enemyPos = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
            transform.position = new Vector2(enemyPos.x, transform.position.y);
            anim.SetInteger("AnimState", 2);
        }
    }

    void Calm()
    {
        anim.SetInteger("AnimState", 1);
    }

    private void Attack()
    {
        Fight2D.Action(punchPoint.position, punchRadius, 10, 20, false);
    }
    private void StopAttack()
    {
        hitCD = false;
    }

    private void SpawnDrop()
    {
        GameObject[] drops = { coin, heart };
        Instantiate(drops[new System.Random().Next(drops.Length)], new Vector3(transform.position.x, transform.position.y + 1f), Quaternion.identity);
    }
}
