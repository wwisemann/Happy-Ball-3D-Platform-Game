using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float pushForce = 1000f;
    private float movement;
    private float speed = 7f;
    public Vector3 respawnPoint;
    public GameManager gameManager;
    public AudioSource crashSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        movement = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()  //Fpsye göre bir deðer vererek her pcde iyi çalýþmasýný saðlýyor.
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z);
        FallDetector();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Barrier"))
        {
            gameManager.RespawnPlayer();
            crashSound.Play();
        }
    }

    private void FallDetector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        }
            
    }

}
