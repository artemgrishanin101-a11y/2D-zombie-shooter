using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _Health; 
    [SerializeField] private Transform[] _spawnPoints; 
    [SerializeField] private float _spawnRate;  

    void Start()
    {
        
        InvokeRepeating(nameof(Spawn), 0f, _spawnRate);
    }

    private void Spawn()
    {
        
        int pointIndex = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[pointIndex];

        
        GameObject healthPack = Instantiate(
            _Health,
            spawnPoint.position,
            Quaternion.identity
        );

        
        
    }
}