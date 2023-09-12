using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Random movement direction
    // Random rotation direction
    // On collision, destroy, add to score

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float rotationSpeed = 1;

    [SerializeField] private string projectileTag = "Projectile";

    private float rotationDir;

    private Vector2 movementDir;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rotationDir = GetRandomRotationDir();

        movementDir = GetRandomMovementDir();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // TODO: Random movement direction
        rb.MovePosition(rb.position + movementDir * moveSpeed * Time.deltaTime);

        rb.MoveRotation(rb.rotation + rotationSpeed * rotationDir);
    }

    private int GetRandomRotationDir()
    {
        int number = Random.Range(-1, 2);
        if (number < 0)
        {
            return -1;
        } else
        {
            return 1;
        }
    }

    private Vector2 GetRandomMovementDir()
    {
        Vector2 dir = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        return dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(projectileTag))
        {
            Destroy(this.gameObject);
        }
    }
}
