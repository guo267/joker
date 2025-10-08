using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed;
    public float jumpSpeed;
    public float MoveController;
    private bool junpController;
    public bool isRunScript;
    private bool isJump;
    public LayerMask GroundLayer;
    private bool isGround;
    private bool isHit;
    private bool isJumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * MoveController, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGround)
        { rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;}

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        if(!isJumping)
        {
            rb.velocity -= new Vector2(0, 12.81f * Time.deltaTime);
        }
  

        isRunScript = MoveController != 0;

        anim.SetBool("isRun", isRunScript);
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(3, 3);
        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-3, 3);
        }

        if (rb.velocity.y > 0.3f)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
        anim.SetBool("isJump", isJump);

        isGround = Physics2D.Raycast(transform.position, Vector2.down, 0.13f, GroundLayer);
        anim.SetBool("isGround", isGround);

        if (Input.GetKey(KeyCode.J))
        {
            isHit = true;
        }
        else
        {
            isHit = false;
        }
        anim.SetBool("isHit", isHit);

        if (isHit == true)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 8;
        }

        if (isHit == true)
        {
            jumpSpeed = 0;
        }
        else
        {
            jumpSpeed = 7;
        }

        if (isJump == true) moveSpeed = 8;

        if (isGround == false) moveSpeed = 8;
    }

}



public class Dogmove : MonoBehaviour
{
    public Transform Pos;
    [SerializeField] private float MoveSpeed;

    // Start is called before the first farme update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos.position, MoveSpeed * Time.deltaTime);


    }

}
