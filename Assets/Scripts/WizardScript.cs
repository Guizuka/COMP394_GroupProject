using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardScript : MonoBehaviour
{
    [Header("Attributes")]
    public int fireSpeed;
    public float verticalSpeed;
    public int numberOfLives = 3;
    [Header("Components")]
    public GameObject bolt;
    public Text lives;
    private Rigidbody2D rb;
    public Animator anim;
    private Vector2 playerDirectionVertical;
    private GameController gc;
    public GameObject firePoint;

    // Start is called before the first frame update
    private void Awake()
    {
        switch (PlayerPrefs.GetString("Difficulty"))
        {
            case "Easy":
                numberOfLives = 3;
                    break;
            case "Medium":
                numberOfLives = 2;
                break;
            case "Hard":
                numberOfLives = 1;
                break;
            default:
                numberOfLives = 3;
                break;
        }

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player up and down
        float directionY = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            directionY = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            directionY = -1;
        }
        playerDirectionVertical = new Vector2(0f, directionY).normalized;
        TextUpdate();
        if (numberOfLives <= 0)
        {
            GameController.PlayerDead = true;
            gc.LevelLost();
            anim.SetTrigger("Dead");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    private void Fire()
    {
        Instantiate(bolt, firePoint.transform.position, Quaternion.identity);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, playerDirectionVertical.y * verticalSpeed * Time.deltaTime);
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