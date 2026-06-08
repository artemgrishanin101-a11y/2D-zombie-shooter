using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;
    [SerializeField] private PlayerMove _player;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, _spawnRate);
    }

    private void Spawn()
    {
        int enemy = Random.Range(0, _enemies.Length);
        int point = Random.Range(0, _spawnPoints.Length);
        GameObject zombie = Instantiate(_enemies[enemy], _spawnPoints[point].position, Quaternion.identity);
        zombie.GetComponent<Enemy>().SetPlayer(_player);
    }
    
}
