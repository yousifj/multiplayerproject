using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : NetworkBehaviour
{
    //config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climeSpeed = 1f;
    [SerializeField] Vector2 deathJump = new Vector2(25, 50);
    [SerializeField] CinemachineVirtualCamera vc;
    [SerializeField] AudioListener audioListener;



    //state
    bool isAlive = true;
    bool canDoubleJump = false;
    float gravityStart;

    //cashed component refernces
    Rigidbody2D rigidBody2D;
    Animator animator;
    Collider2D mycollider2D;
    Collider2D feetBoxcollider2D;
    bool hostPlayer = false;
    public GameObject respawn;
    //keep this object alive when we go to the next level.
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mycollider2D = GetComponent<Collider2D>();
        feetBoxcollider2D = GetComponentInChildren<BoxCollider2D>();
        gravityStart = rigidBody2D.gravityScale;
        if (respawn == null && IsHost)
        {
            respawn = GameObject.FindGameObjectWithTag("Host");
        }
        if (respawn == null && IsClient)
        {
            respawn = GameObject.FindGameObjectWithTag("Client");
        }
        this.transform.position = respawn.transform.position;
        //FindAnyObjectByType<CinemachineScript>().lookAtNew(gameObject,IsHost);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        if (!isAlive) { return; }
        Run();
        Jump();
        Clime();
        if (feetBoxcollider2D.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            Die();
        }

    }
    // When the player first spawn set up the camera
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            audioListener = FindAnyObjectByType<Camera>().GetComponent<AudioListener>();
            vc.Priority = 1;
            audioListener.enabled = true;
        }
        else
        {
            vc.Priority = 0;
        }
    }
    // Check if this player is host for the other MonoBehaviour objects to use.
    public bool statues()
    {
        return hostPlayer;
    }
    // Let player clime 
    private void Clime()
    {

        if (!feetBoxcollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rigidBody2D.gravityScale = gravityStart;
            return;
        }
        rigidBody2D.gravityScale = 0;
        float inputVelocity = Input.GetAxis("Vertical");
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, inputVelocity * climeSpeed);

    }

    private void Run()
    {
        float inputVelocity = Input.GetAxisRaw("Horizontal");
        rigidBody2D.velocity = new Vector2(inputVelocity * runSpeed, rigidBody2D.velocity.y);
        FlipSprite();
        bool playerisMovingHorzantily = Mathf.Abs(rigidBody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRuning", playerisMovingHorzantily);
    }
    private void Jump()
    {
        bool doubleJumpOnce = false;
        bool isGrounded = feetBoxcollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isGrounded)
        {
            doubleJumpOnce = true;
            canDoubleJump = true;
            animator.SetBool("isJumping", false);
           // animator.SetBool("isDoubleJumping", false);
        }
        else if (!isGrounded)
        {
            if (doubleJumpOnce)
            {
                canDoubleJump = true;
                doubleJumpOnce = false;

            }
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {

                animator.SetBool("isJumping", true);
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                rigidBody2D.velocity = jumpVelocity;
                canDoubleJump = true;
                FindObjectOfType<AudioManger>().Play("Jump");
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
             //   animator.SetBool("isDoubleJumping", true);
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                rigidBody2D.velocity = jumpVelocity;
                FindObjectOfType<AudioManger>().Play("Jump");
            }


        }


    }
    // Make player sprite matches where he is faceing
    private void FlipSprite()
    {
        
        bool playerisMovingHorzantily = Mathf.Abs(rigidBody2D.velocity.x) > Mathf.Epsilon;

        if (playerisMovingHorzantily)
        {
            transform.localScale = new Vector3(Mathf.Sign(rigidBody2D.velocity.x), 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.GetComponent<Enemy>())
        //{
        //    Die();
        //}
    }

    public void Die()
    {
        // prevent player from dying multiple times from the same object
        if (isAlive)
        {
            isAlive = false;
            //  animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isDead", true);

            rigidBody2D.velocity = deathJump;
            FindObjectOfType<AudioManger>().Play("Death");
            StartCoroutine(HandelDeath());
        }

    }
    // Handel player death
    IEnumerator HandelDeath()
    {
        //wait few seconds (3.2 is the length of death sound)
        yield return new WaitForSeconds(3.2f);
        //return the player to spawn position
        this.transform.position = respawn.transform.position;
        isAlive = true;
        animator.SetBool("isDead", false);
        //FindObjectOfType<GameSession>().ProcessPlayerDeath();

    }
    public void PlayerDisappear()
    {
        StartCoroutine(HandelWin());
    }

    IEnumerator HandelWin()
    {
     //   animator.SetBool("isDead", true);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
