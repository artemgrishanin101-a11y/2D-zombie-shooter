using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthPotion : MonoBehaviour
{
    [SerializeField] private float _healAmount = 20; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.TryGetComponent(out PlayerMove playerHealth))
        {
            playerHealth.TakeDamage(-_healAmount); 
            Destroy(gameObject); 

        }
    }
}
