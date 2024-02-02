using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private float timerSeconds = 3;

    private bool startTimer = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterTime();
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(transform.up.x, transform.up.y) * bulletSpeed;
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    // TODO: Make timer for Bullet to destroy itself
    void DestroyAfterTime()
    {
        if (startTimer) 
        {
            if (timerSeconds > 0)
            {
                timerSeconds -= Time.deltaTime;
            }
            else
            {
                startTimer = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
