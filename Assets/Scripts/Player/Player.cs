using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    [SerializeField] float _speed = 5f, _jumpForce, _maxLife;
    [SerializeField] Bullet _bulletPrefab;
    [SerializeField] ParticleSystem _shootParticle;
    [SerializeField] Transform _shootPos;


    float _currentLife;
    NetworkRigidbody _rb;

    NetworkInputData _networkInputData;

    float _lastFireTime;
    [Networked(OnChanged = nameof(ShootChangedCallback))] bool isFiring { get; set; }

    private void Start()
    {
        _currentLife = _maxLife;
        _rb = GetComponent<NetworkRigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out _networkInputData))
        {
            Movement(_networkInputData.movementInputH, _networkInputData.movementInputV);

            if (_networkInputData.isJumpPessed)
            {
                Jump();
            }

            if (_networkInputData.isFirePessed)
            {
                Shoot();
            }
        }
        
    }

    void Movement(float _h, float _v)
    {
        Vector3 dir = new Vector3(_h, 0, _v);

        _rb.Rigidbody.velocity = dir * _speed;

        if (dir != Vector3.zero)
        {            
            transform.forward = new Vector3(dir.x, 0f, dir.z).normalized;
        }
    }

    void Jump()
    {
        _rb.Rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    void Shoot()
    {
        if (Time.time - _lastFireTime < 0.15f) return;

        _lastFireTime = Time.time;

        StartCoroutine(ShootCD());

        Bullet b = Runner.Spawn(_bulletPrefab);

        //Bullet b = Instantiate(_bulletPrefab);
        b.transform.position = _shootPos.position;
        b.SetDir(transform.forward);
    }

    IEnumerator ShootCD()
    {
        isFiring = true;        

        yield return new WaitForSeconds(0.15f);

        isFiring = false;
    }

    static void ShootChangedCallback(Changed<Player> changed)
    {
        bool _currentFire = changed.Behaviour.isFiring;

        changed.LoadOld();

        bool previousFire = changed.Behaviour.isFiring;

        if(!previousFire && _currentFire)
        {
            changed.Behaviour._shootParticle.Play();
        }
    }

    public void TakeDamage(float dmg)
    {
        _currentLife -= dmg;
    }
    
}
