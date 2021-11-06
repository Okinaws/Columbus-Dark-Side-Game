using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animations animations;
    public Hp hp;
    public static PlayerController instance;

    public TextMeshProUGUI coinsMenu;
    public int coins = 0;
    public Image stamina;

    public float defaultSpeed = 6f;
    private float speed;
    public float moveX;
    private bool faceRight = true;

    public float jumpForce;
    private bool jump = false;
    public bool grounded = false;
    public Transform groundCheck;
    public LayerMask ground;

    public Transform punch;
    public float punchRadius = 0.6f;
    public bool hitCD = false;

    public bool dash = false;
    public float dashForce = 20f;
    public float dashCD = 5f;
    private float nextDash = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
    }


    void Update()
    {
        if (!animations.isPunching)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveX = 1f;
            }
            else if (moveX != 0f)
            {
                moveX = 0f;
            }

            if (Input.GetMouseButtonDown(1) && !dash && moveX != 0f && grounded)
            {
                if(Time.time > nextDash)
                {
                    dash = true;
                    nextDash = Time.time + dashCD;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                grounded = false;
                jump = true;
            }

            if (!hitCD && Input.GetMouseButtonDown(0))
            {
                hitCD = true;
                Invoke("Punch", 0.3f);
            }

        }
    }

    private void FixedUpdate()
    {
        Move();
        if (dash)
        {
            Fight2D.Action(punch.position, 0.6f, 9, 4.5f, true);
        }

        stamina.fillAmount = (Time.time + dashCD - nextDash) / dashCD;
    }

    void Move()
    {
        grounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.6f), 0, ground);

        if (moveX > 0 && !faceRight)
        {
            Flip();
            hp.bar.fillOrigin = (int) Image.OriginHorizontal.Right;
        }
        else if (moveX < 0 && faceRight)
        {
            Flip();
            hp.bar.fillOrigin = (int)Image.OriginHorizontal.Left;
        }

        if (jump)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (moveX != 0)
        {
            if (dash)
            {
                Dash();
            }
            Run();
        }
    }

    private void Run()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    private void Dash()
    {
        dash = true;
        speed = dashForce;
        Invoke("StopDash", 0.25f);
    }

    private void StopDash()
    {
        speed = defaultSpeed;
        dash = false;
    }

    private void Punch()
    {
        Fight2D.Action(punch.position, punchRadius, 9, 12, false);
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
