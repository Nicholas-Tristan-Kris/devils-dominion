using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Character : MonoBehaviour
{
    
    [Header("Character Settings")]
    [SerializeField] protected float walkSpeed;
    [SerializeField] protected float jumpHeight;
    [SerializeField] protected bool canJump = false;
    [SerializeField] public int maxHealth;
    [SerializeField] protected float healthRegenSpeed = 0.01f;


    public float health;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer; 

    protected bool isBlocking = false;
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
        float newHealth = healthRegenSpeed * Time.deltaTime;
        if ((health + newHealth) <= maxHealth) {
            health += newHealth;
        }
    }


    private void FixedUpdate() {
        Walk();
        if (Input.GetAxis("Jump") > 0 && canJump) {Jump();}
    }

    public void Walk() {
        if (isBlocking) return;
        
        //Change Pos
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * walkSpeed);

        //Flip accordingly
        spriteRenderer.flipX = movement.x > 0 ? true : false;
    }

    public void Jump() {
        //TODO fix jumping mechanic
        rb.AddForce(Vector2.up * jumpHeight * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void Die() {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        walkSpeed = 0; jumpHeight = 0;
        animator.SetTrigger("Die");

    }

    public void RemoveHealth(int lost) {
        health -= lost;
    }
}
