using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Action Settings")]
    [SerializeField] protected bool isBlocking = false;
    [SerializeField] protected AnimationClip blockingAnimation;

    private float timeBlocked = 0f;


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
        if (Input.GetAxis("Block") != 0) {Block(); isBlocking = true; timeBlocked = 0f;}
        if (isBlocking) {
            timeBlocked += Time.deltaTime; 
            if (timeBlocked >= blockingAnimation.length) {
                isBlocking = false; 
                timeBlocked = 0f;
            }
        }
    }

    protected void Block() {
        Debug.Log("Blocking");
        animator.SetTrigger("Block");
        
    }

    protected void DoubleJump() {

    }

    protected void MeleeAttack() {

    }

    protected void RangeAttack() {

    }

    protected void SpecialAttack() {

    }

    

}

