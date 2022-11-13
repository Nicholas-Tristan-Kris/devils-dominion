using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public string character_class = "knight";

    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Sprite[] movementSprites;//0-up 1-right 2-up right
    private SpriteRenderer spriteRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        #if DEVELOPMENT_BUILD
        try {
            if (movementSprites == null) {
                throw new Error("No Sprites");
            }
            if (spriteRenderer == null) {
                throw new Error("No Sprite Renderer");
            }
        } catch {
            Debug.Log("Error Pausing Game");
            Time.timeScale = 0;
        }
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement(Input.GetAxis("Forward"), Input.GetAxis("Right"));
        SpriteChange(); 
        
    }

    private void ProcessMovement(float forward, float right) {
        this.transform.position += new Vector3(0, forward * Time.deltaTime * speed, 0);
        this.transform.position += new Vector3(right * Time.deltaTime * speed, 0, 0);
    }

    private void SpriteChange() {
        float forward = Input.GetAxis("Forward");
        float right = Input.GetAxis("Right");
        
        spriteRenderer.sprite = (forward != 0 && right != 0) ? movementSprites[2] : (right != 0) ? movementSprites[1] : movementSprites[0];;
        spriteRenderer.flipX = right < 0 ? true : false;
        spriteRenderer.flipY = forward < 0 ? true : false;
        
    }
}
