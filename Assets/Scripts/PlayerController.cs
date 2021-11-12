using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpHeight = 5f;

    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerVelocity = playerRb.velocity;
        playerVelocity.x = speed;
        playerRb.velocity = playerVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
