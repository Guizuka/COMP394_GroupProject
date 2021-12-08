using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundRadius = 0.8f;
    public bool isGrounded = false;

    [Header("Movement")]
    public float speed = 5f;
    public float jumpHeight = 5f;
    public bool facingRight = true;

    Animator anim;

    int JumpButton = Animator.StringToHash("JumpButton");
    int AttkButton = Animator.StringToHash("AttkButton");


    public GameObject player;
    private Rigidbody2D playerRb;

    [Header("Player sounds")]
    //Player sounds
    private Sounds soundScript = new Sounds();
    [SerializeField]
    Sounds jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameObject jumpsoundGo = new GameObject("Sound_Jump_" + jumpSound.soundName);
        jumpsoundGo.transform.SetParent(this.transform);
        jumpSound.SetSource(jumpsoundGo.AddComponent<AudioSource>());
        jumpsoundGo.GetComponent<AudioSource>().volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    public void Movement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }
}
