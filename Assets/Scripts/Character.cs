using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{
    

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool canJump = false;
    [SerializeField] private int health;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; 

    private Vector2 movement;

    protected virtual void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update() {
        movement.x = Input.GetAxis("Right");
        movement.y = Input.GetAxis("Forward");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        if (health < 0.001) {
            Die();
        }
    }

    private void FixedUpdate() {
        Walk();
        if (Input.GetAxis("Jump") > 0 && canJump) {Jump();}
    }

    public void Walk() {
        //Change Pos
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * walkSpeed);

        //Flip accordingly
        spriteRenderer.flipX = movement.x > 0 ? true : false;
    }

    public void Jump() {
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void Die() {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        walkSpeed = 0; jumpHeight = 0;
        animator.SetTrigger("Die");

    }
}
