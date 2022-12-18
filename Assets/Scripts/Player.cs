using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Action Settings")]
    [SerializeField] protected AnimationClip blockingAnimation, meleeAnimation, rangeAnimation, specialAnimation;

    private float timeInAnim = 0f;
    private bool isMelee = false, isRange = false, isSpecial = false;


    public Player() : base() {

    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (Input.GetAxis("Block") != 0) {Block(); }
        else if (Input.GetAxis("Melee") != 0) {MeleeAttack();} 
        else if (Input.GetAxis("Range") != 0) {RangeAttack(); } 
        else if (Input.GetAxis("Special") != 0) {SpecialAttack(); }

        if (isBlocking) {
            timeInAnim += Time.deltaTime; 
            if (timeInAnim >= blockingAnimation.length) {
                isBlocking = false; 
                timeInAnim = 0f;
            }
        } else if (isMelee) {
            timeInAnim += Time.deltaTime;
            if (timeInAnim >= meleeAnimation.length) {
                isMelee = !isMelee;
                timeInAnim = 0f;
            }
        } else if (isRange) {
            timeInAnim += Time.deltaTime;
            if (timeInAnim >= rangeAnimation.length) {
                isRange = !isRange;
                timeInAnim = 0f;
            }
        } else if (isSpecial) {
            timeInAnim += Time.deltaTime;
            if (timeInAnim >= specialAnimation.length) {
                isSpecial = !isSpecial;
                timeInAnim = 0f;
            }
        } else {
            timeInAnim = 0f;
        }


    }

    protected void Block() {
        Debug.Log("Blocking");
        isBlocking = true;
        animator.SetTrigger("Block");


    }

    protected void DoubleJump() {

    
    
    }

    protected void MeleeAttack() {
        Debug.Log("Melee Attack");
        isMelee = true;
        animator.SetTrigger("Melee");
    
    
    }

    protected void RangeAttack() {
        Debug.Log("Range Attack");
        isRange = true;
        animator.SetTrigger("Range");
    
    
    }

    protected void SpecialAttack() {
        Debug.Log("Special Attack");
        isSpecial = true;
        animator.SetTrigger("Special");


    }

    

}

