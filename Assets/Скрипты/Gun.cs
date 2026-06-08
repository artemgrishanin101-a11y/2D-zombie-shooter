using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private int _bulletCounts;
    [SerializeField] private TMP_Text _bulletText;

    private Camera _camera;
    private AudioSource _source;
   

    public int Bullets { get => _bulletCounts; set => _bulletCounts = value; }
    void Start()
    {
        _camera = Camera.main;
        _source = GetComponent<AudioSource>();
        _bulletText.text = _bulletCounts.ToString();

    }

    void Update()
    {
        Vector3 mouse = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotate = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotate);

        if (Input.GetMouseButtonDown(0) && _bulletCounts > 0)
        {
            _source.Play();
            GameObject bullet = Instantiate(_bullet, _muzzle.position, _muzzle.rotation);
            _bulletCounts--;
            _bulletText.text = _bulletCounts.ToString();
        }
    }
}
