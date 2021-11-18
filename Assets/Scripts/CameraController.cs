using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Speed to move right
    public float horizontalSpeed;
    private Vector2 playerDirectionHorizontal;

    // Update is called once per frame
    void Update()
    {

        //Move the player right automatically
        playerDirectionHorizontal = new Vector2(horizontalSpeed * Time.deltaTime, 0);
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(playerDirectionHorizontal.x, 0, 0);
    }
}
