using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField]
    float moveSpeed;

    [Header("Dash")]
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashDuration;
    [SerializeField]
    float dashCooldown;
    bool isDashing;
    bool canDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;

        if (Input.GetAxisRaw("Jump")>0 && canDash)
        {
            StartCoroutine(Dash());
        }
        Debug.Log(movement);
    }

    private void FixedUpdate()
    {
        if (isDashing)
            return;

        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        if(Input.GetAxisRaw("Vertical")==0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(.65f * dashSpeed, .37f * dashSpeed);
        }
        else
        {
            rb.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        }

        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
