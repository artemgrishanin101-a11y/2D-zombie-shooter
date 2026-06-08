using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private PlayerMove _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private AudioClip[] _audios;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    private bool _canDamage;
    private AudioSource _source;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        _canDamage = true;
        _source = GetComponent<AudioSource>();
    }
    public void SetPlayer(PlayerMove player)
    {
        _player = player;
    }

    
    void Update()
    {
        _rb.velocity = (_player.transform.position - transform.position).normalized * _speed;
        if (transform.position.x < _player.transform.position.x)
            _sr.flipX = false;
        if (transform.position.x > _player.transform.position.x)
            _sr.flipX = true;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _animator.SetBool("Dead", true);
            GetComponent<Collider2D>().enabled = false;
            enabled = false;
            Destroy(gameObject, 2);
            _rb.bodyType = RigidbodyType2D.Static;
            _source.PlayOneShot(_audios[1]);
            PointsCounter.action.Invoke();
        }
        else
        {
            _animator.SetTrigger("Hit");
            _source.PlayOneShot(_audios[0]);
        }   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerMove player))
        {
            if (_canDamage)
                StartCoroutine(Attack(player));
        }
    }

    private IEnumerator Attack(PlayerMove player)
    {
        _canDamage = false;
        player.TakeDamage(_damage);
        yield return new WaitForSeconds(1);
        _canDamage = true;
    }
}
