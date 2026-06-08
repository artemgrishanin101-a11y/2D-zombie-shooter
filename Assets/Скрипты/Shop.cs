using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private PointsCounter _pointscounter;
    void Start()
    {
        
    }

    public void Buy()
    {
        if (_pointscounter.Count >= 10)
        {
            _pointscounter.Count -= 10;
            _gun.Bullets += 50;
        }
    }

    public void GunEnabled(bool isEnabled)
    {
        _gun.enabled = isEnabled;
    }
}
