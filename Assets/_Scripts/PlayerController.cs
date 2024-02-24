using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet; // Assign in Editor
    [SerializeField] private Transform bulletSpawnPoint; // Assign in Editor

    [SerializeField] private string hazardTag = "Hazard";
    
    [SerializeField] private float turnSpeed = 15;
    [SerializeField] private float thrustSpeed = 10;
    [SerializeField] private float bulletCoolDownTime = 1;

    private AudioSource shootSound;

    private Rigidbody2D playerBody;

    private float hInput;
    private float activeTimerSeconds;

    private bool isThrusting = false;
    private bool canShoot = true;

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Get input
        InputHandler();

        // Shoot cooldown
        CooldownTimer();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            LevelManager.ChangeLevel(LevelManager.MainMenu);
        }
    }

    private void FixedUpdate()
    {
        playerBody.AddTorque(-hInput * turnSpeed);

        if (isThrusting)
        {
            playerBody.AddForce(transform.up * thrustSpeed);
        }
    }

    // TODO: Replace with New Input System
    private void InputHandler()
    {
        // Movement
        hInput = Input.GetAxisRaw("Horizontal");
        isThrusting = Input.GetKey(KeyCode.W);

        // Shooting
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Shoot bullet
        if (canShoot)
        {
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            canShoot = false;
            shootSound.Play();

            // Start cooldown timer
            activeTimerSeconds = bulletCoolDownTime;
        }
    }

    private void CooldownTimer()
    {
        if (!canShoot)
        {
            if (activeTimerSeconds > 0)
            {
                activeTimerSeconds -= Time.deltaTime;
            }
            else
            {
                canShoot = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(hazardTag))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        print("took damage");
    }
}