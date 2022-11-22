using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{
    

    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float jumpHeight;
    [SerializeField] protected bool canJump = false;
    [SerializeField] protected int maxHealth = 100;

    protected int health;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer; 

    private Vector2 movement;

    protected virtual void Start() {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    protected virtual void Update() {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
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
        //TODO fix jumping mechanic
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    public void Die() {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        walkSpeed = 0; jumpHeight = 0;
        animator.SetTrigger("Die");

    }
}
