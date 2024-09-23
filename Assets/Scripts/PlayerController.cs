using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rB;
    public float jumpForce;
    public float runSpeed;
    private float activeSpeed;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    private bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public TrailRenderer tr;

    public Animator anim;

    public float knockbackLength, knockbackSpeed;
    private float knockbackCounter;

    private GameObject currentTeleporter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (knockbackCounter <= 0)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentTeleporter != null)
                {
                    transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                }
            }



            if (isDashing)
            {
                return;
            }            

            activeSpeed = moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                activeSpeed = runSpeed;
            }
            rB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, rB.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded == true)
                {
                    //rB.velocity = new Vector2(rB.velocity.x, jumpForce);
                    Jump();
                }
            }

            if (Input.GetKeyDown(KeyCode.C) && canDash)
            {
                StartCoroutine(Dash());
            }

            if (rB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            if (rB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            rB.velocity = new Vector2(knockbackSpeed * -transform.localScale.x, rB.velocity.y);
        }

        anim.SetFloat("speed", Mathf.Abs(rB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("ySpeed", rB.velocity.y);
    }

    void Jump()
    {
        rB.velocity = new Vector2(rB.velocity.x, jumpForce);
    }

    public void KnockBack()
    {
        rB.velocity = new Vector2(0f, jumpForce * 0.5f);
        anim.SetTrigger("isKnockingBack");

        knockbackCounter = knockbackLength;
    }   

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rB.gravityScale;
        rB.gravityScale = 0f;
        rB.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rB.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void BouncePad(float bounceAmount)
    {
        rB.velocity = new Vector2(rB.velocity.x, bounceAmount);
        anim.SetBool("isGrounded", true);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
