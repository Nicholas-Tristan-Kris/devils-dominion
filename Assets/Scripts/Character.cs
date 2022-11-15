using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private bool canJump = false;
    
    [SerializeField] private Sprite[] walkForwardSprites;
    [SerializeField] private Sprite[] walkRightSprites;
    [SerializeField] private Sprite[] walkForwardRightSprites;
    [SerializeField] private Sprite[] jumpSprites;

    private SpriteRenderer spriteRenderer; 

    public Character() {
    }

    private void Update() {
    
    }
    
    public void Walk(float forward, float right) {
        //Change Pos
        this.transform.position += new Vector3(0, forward * Time.deltaTime * walkSpeed, 0);
        this.transform.position += new Vector3(right * Time.deltaTime * walkSpeed, 0, 0);

        //Set according sprite
        spriteRenderer.sprite = (forward != 0 && right != 0) ? walkForwardSprites[2] : (right != 0) ? walkForwardSprites[1] : walkForwardSprites[0];;
        spriteRenderer.flipX = right < 0 ? true : false;
        spriteRenderer.flipY = forward < 0 ? true : false;
    }
}
