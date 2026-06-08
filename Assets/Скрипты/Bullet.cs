using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _damage;

    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Vector2 direction = transform.TransformDirection(Vector2.up);
        _rb.AddForce(direction * _force, ForceMode2D.Impulse);

        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);
        
        Destroy(gameObject);
    }

} 


