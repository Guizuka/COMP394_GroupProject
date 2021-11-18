using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    //Speed to move up and down
    public float verticalSpeed;
    private Rigidbody2D rb;
    public Animator anim;
    private Vector2 playerDirectionVertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player up and down
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirectionVertical = new Vector2(0f, directionY).normalized;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, playerDirectionVertical.y * verticalSpeed);
    }
}
