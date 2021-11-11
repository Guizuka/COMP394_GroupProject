using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;

    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.velocity = new Vector3(speed, 0, 0);
    }
}
