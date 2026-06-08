using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private SpriteRenderer _gun;
    [SerializeField] private float _health;
    [SerializeField] private Slider _HPSlider;
    [SerializeField] private AudioClip[] _audios;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Camera _camera;
    private AudioSource _source;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _HPSlider.maxValue = _health;
        _HPSlider.value = _health;
        _source = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(hor, ver).normalized * _speed;

        if (hor != 0 || ver != 0)
            _animator.SetBool("run", true);
        else
            _animator.SetBool("run", false);

        if (Input.mousePosition.x < _camera.pixelWidth / 2)
        {
            transform.rotation = Quaternion.Euler(Vector2.up * 180);
            _gun.flipY = true;
        }
        if (Input.mousePosition.x > _camera.pixelWidth / 2)
        {
            transform.rotation = Quaternion.identity;
            _gun.flipY = false;
        }

    }

    public void TakeDamage(float damage)
    {
        _HPSlider.value -= damage;
        _health = _HPSlider.value;


        
        if (_health <= 0 && enabled)
        {
            _animator.SetTrigger("Dead");
            enabled = false;
            _gun.gameObject.SetActive(false);
            _source.PlayOneShot(_audios[0]);
        }
        else if (enabled && damage > 0)
        {
            _source.PlayOneShot(_audios[1]);
        }
    }
}
