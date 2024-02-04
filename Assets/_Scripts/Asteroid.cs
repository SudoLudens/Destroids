using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Random movement direction
    // Random rotation direction
    // On collision, destroy, add to score

    [SerializeField] private float _moveSpeed = 1;
    [SerializeField] private float _rotationSpeed = 1;

    [SerializeField] private string _projectileTag = "Projectile";

    private float _rotationDir;

    private Vector2 _movementDir;

    private Rigidbody2D _rigidBody;
    private ObjectSpawner _objectSpawner;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _objectSpawner = GetComponent<ObjectSpawner>();

        _rotationDir = GetRandomRotationDir();

        _movementDir = GetRandomMovementDir();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // TODO: Random movement direction
        _rigidBody.MovePosition(_rigidBody.position + _movementDir * _moveSpeed * Time.deltaTime);

        _rigidBody.MoveRotation(_rigidBody.rotation + _rotationSpeed * _rotationDir);
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
        if (collision.gameObject.CompareTag(_projectileTag))
        {
            Destroy(this.gameObject);
        }
    }
}
