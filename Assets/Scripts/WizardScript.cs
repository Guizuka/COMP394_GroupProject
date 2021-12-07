using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardScript : MonoBehaviour
{
    [Header("Attributes")]
    public int fireSpeed;
    private int rateOfFireSpeed;
    public float verticalSpeed;
    public int numberOfLives = 3;
    [Header("Components")]
    public GameObject bolt;
    public Text lives;
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
        TextUpdate();
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, playerDirectionVertical.y * verticalSpeed);
    }
    public void TakeDamage()
    {
        numberOfLives--;
    }
    public void TextUpdate()
    {
        lives.text = "Player Lives: " + numberOfLives;
    }
}